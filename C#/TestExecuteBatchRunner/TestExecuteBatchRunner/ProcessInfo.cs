using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestExecuteBatchRunner
{
    public class ProcessInfo
    {

        public string TestExecuteExe { get; set; }
        public string TestProjectSuite { get; set; }
        public string TestProject { get; set; }
        public string ScriptFile { get; set; }
        public string FunctionCall { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public List<string> ExceptionText { get; set; }
        public string ProcessExitText { get; set; }
        public int ProcessExitCode { get; set; }
        private bool TestStarted { get; set; }
        private string tab = "\t";

        public ProcessInfo(string TestExecute)
        {
            TestExecuteExe = TestExecute;
            TestProjectSuite = null;
            TestProject = null;
            ScriptFile = null;
            FunctionCall = null;
            StartTime = DateTime.MinValue;
            EndTime = DateTime.MinValue;
            ExecutionTime = TimeSpan.MinValue;
            ExceptionText = new List<string>();
            ExceptionText.Clear();
            ProcessExitText = null;
            ProcessExitCode = -1000;
            TestStarted = false;
        }

        public string GetCommandLineString()
        {
            string cmdLineString = null;
            if (null == TestProjectSuite)
            {
                return cmdLineString;
            }
            cmdLineString = String.Format("\"{0}\" ", TestProjectSuite);
            cmdLineString += "/r ";
            if (TestProject != null)
            {
                cmdLineString += String.Format("/p:{0} ", TestProject);
            }
            if( ScriptFile != null )
            {
                cmdLineString += String.Format("/u:{0} ", Path.GetFileNameWithoutExtension(ScriptFile));
            }
            if( FunctionCall != null )
            {
                cmdLineString += String.Format("/rt:{0} ", FunctionCall);
            }
            cmdLineString += "/e /SilentMode";
            return cmdLineString;
        }

        public void StartExecution()
        {
            StartTime = DateTime.Now;
            TestStarted = true;
        }

        public void StopExecution()
        {
            EndTime = DateTime.Now;
            TestStarted = false;
            ExecutionTime = EndTime - StartTime;
        }

        public void GetXmlOutput(List<string> output, int indent)
        {
            string input = GetPreTabs(indent) + "<testcase";
            if (null != ScriptFile)
            {
                input += String.Format(" script=\"{0}\"", ScriptFile);
            }
            if (DateTime.MinValue != StartTime)
            {
                input += String.Format(" starttime=\"{0} {1}\"", StartTime.ToShortDateString(), StartTime.ToShortTimeString());
            }
            if (DateTime.MinValue != EndTime)
            {
                input += String.Format(" endtime=\"{0} {1}\"", EndTime.ToShortDateString(), EndTime.ToShortTimeString());
            }
            if (TimeSpan.MinValue != ExecutionTime)
            {
                input += String.Format(" executiontime=\"{0:0}:{1:00}:{2:00}.{3:0000}\"", ExecutionTime.Hours, ExecutionTime.Minutes, ExecutionTime.Seconds, ExecutionTime.Milliseconds);
            }
            input += ">";
            output.Add(input);
            //////////
            input = GetPreTabs(indent + 1) + "<command>";
            output.Add(input);
            //////////
            input = GetPreTabs(indent + 2) + "\"" + TestExecuteExe + "\" ";
            input += GetCommandLineString();
            output.Add(input);
            //////////
            input = GetPreTabs(indent + 1) + "</command>";
            output.Add(input);
            //////////
            input = GetPreTabs(indent + 1) + "<exitcode";
            if (-1000 != ProcessExitCode)
            {
                input += " code=\"" + ProcessExitCode + "\"";
            }
            if (null != ProcessExitText)
            {
                input += ">";
                output.Add(input);
                input = GetPreTabs(indent + 2) + ProcessExitText;
                output.Add(input);
                input = GetPreTabs(indent + 1) + "</exitcode>";
            }
            else
            {
                input += "/>";
            }
            output.Add(input);
            //////////
            if (0 != ExceptionText.Count)
            {
                input = GetPreTabs(indent + 1) + "<exceptions>";
                output.Add(input);
                //////////
                foreach (string exception in ExceptionText)
                {
                    input = GetPreTabs(indent + 1) + "<exception>";
                    output.Add(input);
                    //////////
                    input = GetPreTabs(indent + 2) + exception;
                    output.Add(input);
                    //////////
                    input = GetPreTabs(indent + 1) + "</exception>";
                    output.Add(input);
                }
                input = GetPreTabs(indent + 1) + "</exceptions>";
                output.Add(input);
            }
            //////////
            input = GetPreTabs(indent) + "</testcase>";
            output.Add(input);
        }

        private string GetPreTabs(int indent)
        {
            string tabs = "";
            for (int i = 0; i < indent; i++)
            {
                tabs += tab;
            }
            return tabs;
        }

    }
}
