using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JavaExtensionParser
{
    public class DoxygenBuilder
    {

        private DirectoryInfo Path = null;
        private DirectoryInfo Target = null;
        private ArrayList input = new ArrayList();
        private string targetDir = "";
        private string targetName = "";

        public DoxygenBuilder(DirectoryInfo path, DirectoryInfo target)
        {
            this.Path = path;
            this.Target = target;
        }

        public bool ParseScriptFiles()
        {
            bool retValue = true;
            foreach (FileInfo file in Path.GetFiles("*.js"))
            {
                MyLogger.Log("Parsing file " + file.FullName + ": " + Environment.NewLine);
                MyLogger.IncreaseIndent();
                if (false == ParseScriptFile(file) && true == retValue)
                {
                    MyLogger.Alert("First failure occured on file " + file.Name + ": " + Environment.NewLine);
                    retValue = false;
                }
                MyLogger.Log("Done parsing file " + file.Name + "." + Environment.NewLine);
                MyLogger.Log("Writing file " + file.Name + " as cpp." + Environment.NewLine);
                PrintDoxygenFile();
                MyLogger.Log("Done writing file " + file.Name + " as cpp." + Environment.NewLine);
                MyLogger.DecreaseIndent();
            }
            return retValue;
        }

        private bool ParseScriptFile(FileInfo file)
        {
            
            bool retValue = true;
            input.Clear();
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                bool funcFound = false;
                string funcName = "";
                int isClass = 0;

                string line = "";
                string function = @"^function ([A-Za-z0-9_]+)\(.*$";
                string classFunction = @"^([ \t]*)this\.([A-Za-z0-9]+)(.*)function(.*)$";
                string comment = @"^([ \t]*)\/\/\*.*$";
                string classParam = @"^([ \t]*)this\.([A-Za-z0-9]+) = (.*)$";
                string extension = @"^([ \t]*)(.*)(_[A-Z0-9]+)\.([A-Za-z0-9]+)\.(.*)$";

                Regex functionRegex = new Regex(function, RegexOptions.Multiline);
                Regex classFunctionRegex = new Regex(classFunction, RegexOptions.Multiline);
                Regex commentRegex = new Regex(comment, RegexOptions.Multiline);
                Regex classParamRegex = new Regex(classParam, RegexOptions.Multiline);
                Regex extensionRegex = new Regex(extension, RegexOptions.Multiline);

                int dirlength = Target.FullName.Length - 8;
                targetDir = Target.FullName;
                targetDir += Path.FullName.Substring(dirlength) + "\\";
                targetName += file.Name.Replace(".js", ".cpp");

                while ((line = reader.ReadLine()) != null)
                {
                    Match functionMatch = functionRegex.Match(line);
                    Match classFunctionMatch = classFunctionRegex.Match(line);
                    Match classParamMatch = classParamRegex.Match(line);
                    if (false == functionMatch.Success &&
                        false == classFunctionMatch.Success && 
                        false == classParamMatch.Success )
                    {
                        Match commentMatch = commentRegex.Match(line);
                        Match extensionMatch = extensionRegex.Match(line);
                        if (false == commentMatch.Success && true == funcFound)
                        {
                            string ToBuild = "";
                            foreach (string str in funcName.Split(' '))
                            {
                                if (str.Equals("function"))
                                {
                                    ToBuild = "void";
                                }
                                else
                                {
                                    ToBuild += " " + str;
                                }
                            }
                            MyLogger.Alert("No function name provided for function \"" + funcName + "\" temporary replace is: \"" + ToBuild + "\"." + Environment.NewLine);
                            input.Add(ToBuild);
                        }
                        if (commentMatch.Success)
                        {
                            if (isClass == 0 && line.Contains("class")) 
                            {
                                isClass = 1;
                            }
                            else if (isClass == 1 && line.Contains("public:"))
                            {
                                isClass = 2;
                            }
                            if (line.Contains("("))
                            {
                                input.Add(line.Replace("//*", "").Replace(";", ""));
                            }
                            else
                            {
                                input.Add(line.Replace("//*", ""));
                            }
                        }
                        else if (extensionMatch.Success)
                        {
                            string ToBuild = "";
                            foreach (string str in line.Split(' '))
                            {
                                string add = "";
                                if (1 < str.Count(f => f == '.'))
                                {
                                    add = str.Replace(".", "::");
                                }
                                else
                                {
                                    add = str;
                                }
                                if (ToBuild.Length > 0)
                                {
                                    ToBuild += " ";
                                }
                                ToBuild += add;
                            }
                            input.Add(ToBuild); // Remake to CPP method calling
                        }
                        else
                        {
                            input.Add(line);
                        }
                        if (0 != isClass &&
                            false == line.Contains("class") &&
                            false == line.Contains("public:"))
                        {
                            isClass = 0;
                        }
                        funcFound = false;
                    }
                    else if (true == functionMatch.Success && isClass != 2)
                    {
                        funcName = line;
                        funcFound = true;
                    }
                }
            }
           
            return retValue;
        }

        private void PrintDoxygenFile()
        {
            DirectoryInfo Target = new DirectoryInfo(targetDir);
            if ( false == Target.Exists )
            {
                Target.Create();
            }
            using (StreamWriter outfile = new StreamWriter(targetDir + targetName, true))
            {
                foreach (string str in input)
                {
                    outfile.WriteLine(str);
                }
                outfile.Close();
            }
            targetDir = "";
            targetName = "";
        }

    }
}
