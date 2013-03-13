using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TestExecuteBatchRunner
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        public string TestExecute { get; set; }
        public string ProjectSuite { get; set; }
        public string Project { get; set; }
        public string[] ScriptFiles { get; set; }
        public string Function { get; set; }
        public int TimeOutInSeconds { get; set; }
        public string Debug { get; set; }
        private bool BatchCompleted { get; set; }
        private bool PauseExecute { get; set; }
        private bool IsWorking { get; set; }
        private string CurrentTest { get; set; }
        private Process CurrentProcess { get; set; }

        private void EnableControls()
        {
            btn_play.Enabled = ( ( !bgw_execute.IsBusy || PauseExecute ) && !BatchCompleted );
            btn_pause.Enabled = (!btn_play.Enabled && !BatchCompleted);
            btn_stop.Enabled = !btn_play.Enabled;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            IsWorking = false;
            PauseExecute = true;
            if (null != CurrentProcess && !CurrentProcess.HasExited)
            {
                CurrentProcess.Kill();
                CurrentProcess.WaitForExit();
            }
            PauseExecute = false;
            bgw_execute.CancelAsync();
            tmr_timeout.Stop();
            this.Close();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            if ( 0 == TestExecute.Length )
            {
                Debug = "No argument provided for TestExecute parameter.";
                this.Close();
            }
            if (0 == ProjectSuite.Length)
            {
                Debug = "No argument provided for ProjectSuite parameter.";
                this.Close();
            }
            if (0 == Project.Length)
            {
                Debug = "No argument provided for Project parameter.";
                this.Close();
            }
            if (0 == ScriptFiles.Length)
            {
                Debug = "No argument provided for ScriptFiles parameter.";
                this.Close();
            }
            if (0 == Function.Length)
            {
                Debug = "No argument provided for Function parameter.";
                this.Close();
            }
            PauseExecute = false;
            BatchCompleted = false;
            CurrentProcess = null;
            CurrentTest = "";
            TimeOutInSeconds = 3600;
            EnableControls();
        }

        
        private void bgw_execute_DoWork(object sender, DoWorkEventArgs e)
        {
            int noOfFiles = ScriptFiles.Length;
            string strCmdText;
            MyLogger.Log(String.Format("Starting batchrun of {0} files.", noOfFiles));
            for (int currentFile = 0; currentFile < noOfFiles && true == IsWorking; currentFile++)
            {
                while (true == PauseExecute)
                {
                    System.Threading.Thread.Sleep(100);
                }
                CurrentTest = ScriptFiles[currentFile];
                strCmdText = "\"" + ProjectSuite + "\" ";
                strCmdText += "/r /p:" + Project + " ";
                strCmdText += "/u:" + Path.GetFileNameWithoutExtension(CurrentTest) + " ";
                strCmdText += "/rt:" + Function + " /e /SilentMode";
                try
                {
                    MyLogger.Log("Starting execute TestComplete with arguments: \"" + strCmdText + "\".");
                    ProcessStartInfo psi = new ProcessStartInfo(TestExecute, strCmdText);
                    CurrentProcess = Process.Start(psi);
                    CurrentProcess.WaitForExit();
                    switch (CurrentProcess.ExitCode)
                    {
                        case 0:
                        {
                            MyLogger.Log(String.Format("Test {0} did not produce errors or warnings (Exit Code 0).", CurrentTest));
                            break;
                        }
                        case 1:
                        {
                            MyLogger.Log(String.Format("Test {0} results include warnings but no errors (Exit Code 1).", CurrentTest));
                            break;
                        }
                        case 2:
                        {
                            MyLogger.Log(String.Format("Test {0} results include errors (Exit Code 2).", CurrentTest));
                            break;
                        }
                        case 3:
                        {
                            MyLogger.Alert(String.Format("Test {0} cannot be executed (Exit Code 3).", CurrentTest));
                            break;
                        }
                        case 1000:
                        {
                            MyLogger.Alert(String.Format("Test {0} cannot be executed because of another instance of TestComplete or TestExecute is running (Exit Code 1000).", CurrentTest));
                            break;
                        }
                        default:
                        {
                            MyLogger.Alert(String.Format("Test {0} returned unknown Exit code {1}.", CurrentTest, CurrentProcess.ExitCode));
                            break;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MyLogger.Alert("Cmd exception: " + exception.Message);
                }
                float percentage = (float)(currentFile + 1) / (float)noOfFiles;
                percentage *= 100;
                int progress = (int)Math.Round(percentage);
                bgw_execute.ReportProgress(progress);
                System.Threading.Thread.Sleep(1000);
            }
            CurrentTest = "";
            CurrentProcess = null;
            BatchCompleted = true;
        }

        private void bgw_execute_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prb_progress.Value = e.ProgressPercentage;
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            if (true == PauseExecute)
            {
                PauseExecute = false;
            }
            else
            {
                bgw_execute.RunWorkerAsync();
                IsWorking = true;
            }
            System.Threading.Thread.Sleep(100);
            tmr_timeout.Start();
            EnableControls();
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            PauseExecute = true;
            System.Threading.Thread.Sleep(100);
            EnableControls();
        }

        private string m_currentTest;
        private DateTime m_currentTime;
        private static bool doOnce = true;
        private void tmr_timeout_Tick(object sender, EventArgs e)
        {
            if (CurrentTest == "")
            {
                if (true == BatchCompleted && true == doOnce)
                {
                    EnableControls();
                    btn_stop.Text = "Exit";
                    doOnce = false; 
                }
                return;
            }
            else if (m_currentTest != CurrentTest)
            {
                m_currentTest = CurrentTest;
                m_currentTime = DateTime.Now;
                this.Activate();
            }
            TimeSpan duration = DateTime.Now - m_currentTime;
            string strInfo = String.Format("Running file \"{0}\" execute time: {1:0}:{2:00}:{3:00}.", m_currentTest, duration.Hours, duration.Minutes, duration.Seconds);
            if (TimeOutInSeconds < duration.TotalSeconds && null != CurrentProcess)
            {
                tmr_timeout.Stop();
                MyLogger.Alert(String.Format("Killing testcase {0} because timeout occured.", CurrentTest));
                PauseExecute = true;
                try
                {
                    if (!CurrentProcess.HasExited)
                    {
                        CurrentProcess.Kill();
                        CurrentProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    MyLogger.Alert(String.Format("Exception when killing process: \"{0}\".", ex.Message));
                }
                PauseExecute = false;
                tmr_timeout.Start();
            }
            lbl_information.Text = strInfo;
        }
    }
}
