using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace TestExecuteBatchRunner
{
    public static class MyLogger
    {
        private static List<string> log = new List<string>();

        public static event EventHandler LogAdded;

        private static string indent = "";

        private static string folder = "log";

        private static int CurrentLogIndex = 0;

        public static void Log(string message)
        {
            log.Add(indent + message);

            if (LogAdded != null)
                LogAdded(null, EventArgs.Empty);
        }

        public static void IncreaseIndent()
        {
            indent += "  ";
        }

        public static void DecreaseIndent()
        {
            if (indent.Length > 2)
            {
                indent = indent.Substring(0, indent.Length - 2);
            }
            else
            {
                indent = "";
            }
        }

        public static void Alert(string message)
        {
            log.Add(indent + "Alert - " + message);

            if (LogAdded != null)
                LogAdded(null, EventArgs.Empty);
        }

        public static void WriteOutput(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            if( !String.IsNullOrEmpty(outLine.Data) )
            {
                Log(outLine.Data + Environment.NewLine);
            }
        }

        public static void WriteError(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            if( !String.IsNullOrEmpty(outLine.Data))
            {
                Alert(outLine.Data + Environment.NewLine);
            }
        }

        public static void NewLine()
        {
            log.Add(Environment.NewLine);

            if (LogAdded != null)
                LogAdded(null, EventArgs.Empty);
        }

        public static string GetLastLog()
        {
            if (log.Count > 0)
                return log[log.Count - 1];
            else
                return null;
        }

        public static bool IsLastEntry()
        {
            return (CurrentLogIndex == log.Count);
        }

        public static string GetNextLog()
        {
            if (true == IsLastEntry())
            {
                return "Alert - GetNextLog: accessed when last entry already fetched.";
            }
            return log[CurrentLogIndex++];
        }

        public static void ResetLog()
        {
            CurrentLogIndex = 0;
            log.Clear();
        }

        public static void SetLogFolder(string _folder)
        {
            folder = _folder;
        }

        public static bool WriteLogToFile(string text)
        {
            bool retValue = true;
            DirectoryInfo target = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\" + folder);
            if (!target.Exists)
            {
                target.Create();
            }
            string filename = "log_" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString().Replace(":",".") + "." + DateTime.Now.Millisecond.ToString() + ".log";
            using (StreamWriter writer = new StreamWriter(target.FullName + "\\" + filename))
	        {
	            writer.Write(text);
                writer.Close();
	        }
            return retValue;
        }

    }
}
