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

namespace JavaExtensionParser
{
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
            MyLogger.LogAdded += new EventHandler(MyLogger_LogAdded);
            btn_clear.Enabled = FileExistsRecursive(Directory.GetCurrentDirectory(), "*.old");
            cbx_doBackup.Checked = false;
            cbx_parseXml.Checked = true;
            cbx_savelog.Checked = false;
            tbx_parseFile.Text = "generate javaclasses.bat";
            tbx_parseFile.Enabled = cbx_parseXml.Checked;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            MyLogger.LogAdded -= new EventHandler(MyLogger_LogAdded);
            ClearLog();
            this.Close();
        }

        private void btn_parse_Click(object sender, EventArgs e)
        {
            btn_parse.Enabled = false;
            ClearLog();
            if (true == cbx_parseXml.Checked)
            {
                try
                {
                    Process proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = tbx_parseFile.Text,
                            Arguments = "",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true
                        }
                    };
                    proc.OutputDataReceived += new DataReceivedEventHandler(MyLogger.WriteOutput);
                    proc.ErrorDataReceived += new DataReceivedEventHandler(MyLogger.WriteError);
                    proc.Start();
                    proc.BeginErrorReadLine();
                    proc.BeginOutputReadLine();
                    proc.WaitForExit();
                }
                catch (Exception ex)
                {
                    MyLogger.Alert(ex.Message + Environment.NewLine);
                }
            }
            string rootdir = Directory.GetCurrentDirectory();
            string fileWrite = "";
            try
            {
                DirectoryInfo[] DI = new DirectoryInfo(rootdir).GetDirectories("*.*", SearchOption.AllDirectories);
                foreach (DirectoryInfo D1 in DI)
                {
                    //rtb_information.Text += "Directory:" + D1.Name + Environment.NewLine;
                    DescriptionBuilder builder = new DescriptionBuilder(D1, cbx_doBackup.Checked);
                    fileWrite = builder.ParseScriptFiles();
                    //rtb_information.Text += builder.GetText();
                }
            }
            catch (DirectoryNotFoundException dEX)
            {
                MyLogger.Alert("Directory Not Found " + dEX.Message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MyLogger.Alert(ex.Message + Environment.NewLine);
            }
            if (true == cbx_doBackup.Checked)
            {
                btn_clear.Enabled = FileExistsRecursive(Directory.GetCurrentDirectory(), "*.old");
            }
            else
            {
                DirectoryInfo[] DI = new DirectoryInfo(rootdir).GetDirectories("*.*", SearchOption.AllDirectories);
                Delete delObject = new Delete(DI);
                delObject.ClearFiles();
            }
            btn_parse.Enabled = true;
        }

        private void MyLogger_LogAdded(object sender, EventArgs e)
        {
            int length = rtb_information.TextLength;  // at end of text
            string ToAppend = MyLogger.GetLastLog();
            rtb_information.AppendText(ToAppend);
            if (ToAppend.Contains("Alert -"))
            {
                rtb_information.SelectionStart = length;
                rtb_information.SelectionLength = ToAppend.Length;
                rtb_information.SelectionColor = Color.Red;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            string rootdir = Directory.GetCurrentDirectory();
            DirectoryInfo[] DI = new DirectoryInfo(rootdir).GetDirectories("*.*", SearchOption.AllDirectories);
            Delete delObject = new Delete(DI);
            delObject.ShowDialog();
            btn_clear.Enabled = FileExistsRecursive(Directory.GetCurrentDirectory(), "*.old");
        }

        private bool FileExistsRecursive(string rootPath, string filename)
        {
            string[] files = Directory.GetFiles(rootPath, filename, SearchOption.TopDirectoryOnly);
            if (files.Length > 0)
            {
                return true;
            }
            string [] dirs = Directory.GetDirectories(rootPath);
            foreach (string subDir in dirs)
            {
                if (true == FileExistsRecursive(subDir, filename))
                {
                    return true;
                }
            }

            return false;
        }

        private void cbx_parseXml_CheckStateChanged(object sender, EventArgs e)
        {
            tbx_parseFile.Enabled = cbx_parseXml.Checked;
        }

        private void btn_parse_doxygen_Click(object sender, EventArgs e)
        {
            btn_parse_doxygen.Enabled = false;
            ClearLog();
            string rootdir = Directory.GetCurrentDirectory();
            try
            {
                DirectoryInfo Target = new DirectoryInfo(rootdir + "\\doxygen");
                if (Target.Exists)
                {
                    MyLogger.Log("Directory " + Target.FullName + " exists, deleting." + Environment.NewLine);
                    Directory.Delete(Target.FullName, true);
                }
                DirectoryInfo DoxygenOutput = new DirectoryInfo(rootdir + "\\doc");
                if (DoxygenOutput.Exists)
                {
                    MyLogger.Log("Directory " + DoxygenOutput.FullName + " exists, deleting." + Environment.NewLine);
                    Directory.Delete(DoxygenOutput.FullName, true);
                }
                DirectoryInfo[] DI = new DirectoryInfo(rootdir).GetDirectories("*.*", SearchOption.AllDirectories);
                MyLogger.Log("Creating Target Directory " + Target.FullName + "." + Environment.NewLine);
                Target.Create();
                foreach (DirectoryInfo D1 in DI)
                {
                    if( false == D1.Name.Contains("svn") &&
                        false == D1.Name.Contains("doxygen") &&
                        false == D1.Name.Contains("doc") ) 
                    {
                        DoxygenBuilder builder = new DoxygenBuilder(D1, Target);
                        builder.ParseScriptFiles();
                    }
                }
            }
            catch (DirectoryNotFoundException dEX)
            {
                MyLogger.Alert("Directory Not Found " + dEX.Message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MyLogger.Alert(ex.Message + Environment.NewLine);
            }
            try
            {
                if (DialogResult.OK == MessageBox.Show("Do you want to clear output before generation of doxygen?", "Clear Log", MessageBoxButtons.OKCancel)) {
                    ClearLog();
                }
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "generate doxygen.bat",
                        Arguments = "",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };
                proc.OutputDataReceived += new DataReceivedEventHandler(MyLogger.WriteOutput);
                proc.ErrorDataReceived += new DataReceivedEventHandler(MyLogger.WriteError);
                proc.Start();
                proc.BeginErrorReadLine();
                proc.BeginOutputReadLine();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                MyLogger.Alert(ex.Message + Environment.NewLine);
            }
            btn_parse_doxygen.Enabled = true;
        }

        private void ClearLog()
        {
            if (true == cbx_savelog.Checked && 0 < rtb_information.Text.Length)
            {
                MyLogger.WriteLogToFile(rtb_information.Text);
            }
            rtb_information.Clear();
        }
    }
}
