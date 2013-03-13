using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace TestExecuteBatchRunner
{
    /// <summary>
    /// File Handlr Class that holds information about current folder and it's script.
    /// </summary>
    /// <see cref="http://stackoverflow.com/questions/1469764/run-command-prompt-commands"/>
    public class FileHandler
    {

        public string ScriptFolder { get; set; }
        private string FileFilter { get; set; }
        public List<FileInfo> Files { get; set; }

        public FileHandler(string path, string filter = "")
        {
            ScriptFolder = path;
            FileFilter = filter;
            Files = new List<FileInfo>();
        }

        public void init()
        {
            string[] fileStrings;
            if (FileFilter == "")
            {
                fileStrings = Directory.GetFiles(ScriptFolder);
            }
            else 
            {
                fileStrings = Directory.GetFiles(ScriptFolder, "*.*").
                    Where(file => Regex.IsMatch(file, @"^.+\.(" + FileFilter.Replace("*.", "") + ")$")).ToArray();
            }
            Array.Sort(fileStrings);
            foreach (string str in fileStrings)
            {
                Files.Add(new FileInfo(str));
            }
        }

    }
}
