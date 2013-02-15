using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace JavaExtensionParser
{
    public class DescriptionBuilder
    {

        private string FileName = "description.xml";
        private DirectoryInfo Path = null;
        private ArrayList input = new ArrayList();
        private ArrayList store = new ArrayList();
        private string tab = "  ";
        private string brief = "";
        private bool isPublic = false;
        FileInfo description = null;
        bool FileNotBackedUp = true;
        bool doBackup = false;

        public DescriptionBuilder(DirectoryInfo path, bool _doBackup)
        {
            this.Path = path;
            this.doBackup = _doBackup;
        }

        public string ParseScriptFiles()
        {
            string retValue = "";
            CreateXmlFile();
            PushScriptExtensionGroup();
            foreach (FileInfo file in Path.GetFiles("*.js"))
            {
                if ( true == file.Name.StartsWith("doc_"))
                {
                    MyLogger.Log("Skipping file " + file.Name + ", due to doc_ tag." + Environment.NewLine);
                }
                else
                {
                    MyLogger.Log("Parsing file " + file.Name + ": " + Environment.NewLine);
                    MyLogger.IncreaseIndent();
                    retValue += file.Name + Environment.NewLine;
                    ParseScriptFile(file);
                }
            }
            PopScriptExtensionGroup();
            if( null != description ) 
            {
                using (StreamWriter outfile = new StreamWriter(description.Directory + "\\" + FileName, true))
                {
                    foreach (string str in input)
                    {
                        outfile.WriteLine(str);
                    }
                    outfile.Close();
                }
            }
            return retValue;
        }

        /*
         * <?xml version="1.0" encoding="UTF-8"?>
<ScriptExtensionGroup>
    <ScriptExtension Name ="Alarm Object" Author="Anv" Version="0.1" HomePage ="None">	
		<Script Name ="alarm.js" >
         * */
        protected void ParseScriptFile(FileInfo file)
        {
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                string line;
                bool klassFound = false;
                bool mute = false;
                string comment = @"^(/\*\*| \* | \*\/){1}.*$";
                string klass = @"^\/\/\*class (.*) {.*$";
                string _namespace = @"^\/\/\*namespace (.*) {.*$";
                string strpublic = @"^//\*public:.*$";
                string strprotected = @"^//\*(protected|private):.*$";
                string function = @"^function ([A-Za-z0-9_]+)\(.*$";
                string endClass = @"^\/\/\*};$";

                // Instantiate the regular expression object.
                Regex commentRegex = new Regex(comment, RegexOptions.Multiline);
                Regex klassRegex = new Regex(klass, RegexOptions.Multiline);
                Regex _namespaceRegex = new Regex(_namespace, RegexOptions.Multiline);
                Regex publicRegex = new Regex(strpublic, RegexOptions.Multiline);
                Regex protectedRegex = new Regex(strprotected, RegexOptions.Multiline);
                Regex functionRegex = new Regex(function, RegexOptions.Multiline);
                Regex endClassRegex = new Regex(endClass, RegexOptions.Multiline);
                string NameSpace = null;

                if (true == FileNotBackedUp )
                {
                    description = new FileInfo(file.Directory + "/" + FileName);
                    if (description.Exists)
                    {
                        string dateFormatted = DateTime.Now.ToString().Replace('-', '.').Replace(':', '.');
                        string preBackup = description.Name;
                        description.MoveTo(description.FullName + "." + dateFormatted + ".old");
                        MyLogger.Log("Taking backup of \"" + preBackup + "\" to \"" + description.Name + Environment.NewLine);
                    }
                    else
                    {
                        MyLogger.Log("Didn't find file " + description.Name + " in Directory " + description.Directory + "." + Environment.NewLine);
                    }
                    FileNotBackedUp = false;
                }
                
                while ((line = reader.ReadLine()) != null)
                {
                    // Do something with line
                    Match commentMatch = commentRegex.Match(line);
                    if (commentMatch.Success)
                    {
                        if (0 < store.Count && commentMatch.Groups[1].ToString().Contains("/**") )
                        {
                            MyLogger.Log("New start of comment received before clear of store.");
                            store.Clear();
                        }
                        store.Add(line);
                    }
                    Match NameSpaceMatch = _namespaceRegex.Match(line);
                    if (NameSpaceMatch.Success)
                    {
                        NameSpace = NameSpaceMatch.Groups[1].ToString();
                    }
                    Match klassMatch = klassRegex.Match(line);
                    if (klassMatch.Success)
                    {
                        if (false == klassFound)
                        {
                            MyLogger.Log("Namespace is: " + NameSpace);
                            PushScriptExtension(klassMatch.Groups[1].ToString(), file, NameSpace);
                            klassFound = true;
                        }
                        else
                        {
                            mute = true;
                        }
                    }
                    if (mute && endClassRegex.Match(line).Success)
                    {
                        mute = false;
                    }
                    Match publicMatch = publicRegex.Match(line);
                    if (publicMatch.Success && !mute)
                    {
                        isPublic = true;
                    }
                    Match protectedMatch = protectedRegex.Match(line);
                    if (protectedMatch.Success && !mute)
                    {
                        isPublic = false;
                    }
                    Match functionMatch = functionRegex.Match(line);
                    if (functionMatch.Success)
                    {
                        if (true == isPublic)
                        {
                            CreateMethod(line);
                        }
                        else
                        {
                            MyLogger.Log("Skipping description for function \"" + functionMatch.Groups[1] + "\"." + Environment.NewLine);
                        }
                        store.Clear();
                    }
                }
                if (true == klassFound)
                {
                    PopScriptExtension();
                }
                MyLogger.DecreaseIndent();
                MyLogger.Log("Done parsing file " + file.Name + Environment.NewLine);
            }
        }

        public string GetText()
        {
            string str = "";
            foreach (string s in input)
            {
                str += s + Environment.NewLine;
            }
            return str;
        }

        public string GetDebugText()
        {
            string str = "";
            foreach (string s in store)
            {
                str += s + Environment.NewLine;
            }
            return str;
        }

        private void CreateXmlFile()
        {
            input.Add("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        }

        private void PushScriptExtensionGroup()
        {
            input.Add("<ScriptExtensionGroup>");
        }

        private void PushScriptExtension(string objectName, FileInfo filename, string _namespace = null)
        {
            //<ScriptExtension Name ="Alarm Object" Author="Anv" Version="0.1" HomePage ="None">	
            string name = objectName + " Object";
            string author = "";
            string authorPattern = @"^(.*@author )([A-Za-z0-9]+)$";
            string version = "";
            string versionPattern = @"^(.*@version )([A-Za-z0-9.]+)$";
            string briefPattern = @"^(.*@brief )([A-Za-z0-9 .]+)$";
            string pathPattern = @"^.*\\(_[A-Za-z1-9]+).*$";
            string nameSpace = "ARCHER";
            foreach (string str in store)
            {
                if (Regex.IsMatch(str, authorPattern, RegexOptions.Multiline))
                {
                    if (author != "")
                    {
                        author += ", ";
                    }
                    author += Regex.Match(str, authorPattern).Groups[2].ToString();
                }
                else if (Regex.IsMatch(str, versionPattern, RegexOptions.Multiline))
                {
                    version = Regex.Match(str, versionPattern).Groups[2].ToString();
                }
                else if (Regex.IsMatch(str, briefPattern, RegexOptions.Multiline))
                {
                    brief = Regex.Match(str, briefPattern).Groups[2].ToString();
                }
            }
            if ( Regex.IsMatch(filename.DirectoryName, pathPattern, RegexOptions.Multiline) )
            {
                nameSpace = Regex.Match(filename.DirectoryName, pathPattern).Groups[1].ToString();
                name = objectName + " " + nameSpace.Substring(1) + " Object";
            }
            store.Clear();
            if (author == "")
            {
                MyLogger.Alert("Missing @author tag for " + filename.Name + " class description" + Environment.NewLine);
                author = "TBD";
            }
            if ("" == version)
            {
                MyLogger.Alert("Missing @version tag for " + filename.Name + " class description" + Environment.NewLine);
                version = "TBD";
            }
            input.Add(tab + "<ScriptExtension Name =\"" + name + "\" Author=\"" + author + "\" Version=\"" + version + "\" HomePage=\"None\">");
            input.Add(tab + tab + "<Script Name =\"" + filename.Name + "\">");
            if (null == _namespace)
            {
                input.Add(tab + tab + tab + "<RuntimeObject Name=\"" + objectName + "\" Namespace=\"" + nameSpace + "\">");
            }
            else
            {
                input.Add(tab + tab + tab + "<RuntimeObject Name=\"" + objectName + "\" Namespace=\"" + _namespace + "\">");
            }
        }

        private void CreateMethod(string line)
        {
            //<Method Name="SetSinceFire" Routine="SetSinceFire">
/**
 * Set since fire alarm time in the system
 * <h3>Code Example</h3>
 * @code
 *   ARCHER.Alarm.SetSinceFire(30, 60, 90);
 * @endcode
 * @param [in] alarm Alarm time in seconds
 * @param [in] secondWarning Second warning time in seconds
 * @param [in] firstWarning First warning time in seconds
 */
			//</Method>
            string functionPattern = @"^(.*function )([A-Za-z0-9_]+)\(.*$";
            if (Regex.IsMatch(line, functionPattern, RegexOptions.Multiline))
            {
                string functionName = Regex.Match(line, functionPattern).Groups[2].ToString();
                MyLogger.Log("Adding function \"" + functionName + "\" to description." + Environment.NewLine);
                input.Add(tab + tab + tab + tab + "<Method Name=\"" + functionName + "\" Routine=\"" + functionName + "\">");
                if (0 == store.Count)
                {
                    MyLogger.Alert("Found no viable comment for " + functionName + "." + Environment.NewLine);
                }
                else
                {
                    foreach (string str in store)
                    {
                        string formatted = str;
                        // Compensate for xml special characters.
                        formatted = formatted.Replace("&", "&amp;");
                        formatted = formatted.Replace("<", "&lt;");
                        formatted = formatted.Replace(">", "&gt;");
                        formatted = formatted.Replace("\"", "&quot;");
                        formatted = formatted.Replace("\'", "&#39;");
                        input.Add(formatted);
                    }
                }
                input.Add(tab + tab + tab + tab + "</Method>");
                
            }
        }
        
        private void PopScriptExtension()
        {
            input.Add(tab + tab + tab + "</RuntimeObject>");
            input.Add(tab + tab + "</Script>");
            input.Add(tab + "</ScriptExtension>");
        }

        private void PopScriptExtensionGroup() 
        {
            input.Add("</ScriptExtensionGroup>");
        }
    }
}
