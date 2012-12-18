using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaExtensionParser
{
    public static class MyLogger
    {
        private static List<string> log = new List<string>();

        public static event EventHandler LogAdded;

        private static string indent = "";

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
    }
}
