using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TestExecuteBatchRunner
{
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
            MyLogger.LogAdded += new EventHandler(MyLogger_LogAdded);
        }

        private FileHandler handler = null;
        private int logindex = 0;

        private void EnableControls()
        {
            btn_listfiles.Enabled = ( tbx_scriptfolder.Text.Length != 0 );
            btn_checkall.Enabled = (clx_testcases.Items.Count != 0);
            btn_uncheckall.Enabled = (clx_testcases.Items.Count != 0);
            btn_match.Enabled = ( (tbx_matchfrom.Text.Length > 0) && 
                                    (tbx_matchto.Text.Length > 0) &&
                                    (int.Parse(tbx_matchfrom.Text) < int.Parse(tbx_matchto.Text)) &&
                                    (clx_testcases.Items.Count != 0));
            btn_clear.Enabled = (rtb_logger.Text.Length != 0);
            btn_execute.Enabled = ((clx_testcases.CheckedItems.Count != 0) &&
                                    (tbx_project.Text.Length != 0) &&
                                    (tbx_projectsuite.Text.Length != 0) &&
                                    (tbx_runmethod.Text.Length != 0) &&
                                    (tbx_testexecute.Text.Length != 0));
        }

        private void SetAllCheckStatus(bool status)
        {
            for (int i = 0; i < clx_testcases.Items.Count; i++)
            {
                clx_testcases.SetItemChecked(i, status);
            }
        }

        private delegate void MYLOGGEREVENT(object sender, EventArgs e);
        private void MyLogger_LogAdded(object sender, EventArgs e)
        {
            if (rtb_logger.InvokeRequired)
            {
                rtb_logger.BeginInvoke(new MYLOGGEREVENT(MyLogger_LogAdded), new object[] { sender, e });
            }
            else
            {
                while (false == MyLogger.IsLastEntry())
                {
                    int length = rtb_logger.TextLength;  // at end of text
                    string prefix = string.Format("{0:d3}: ", ++logindex);
                    string ToAppend = prefix + MyLogger.GetNextLog();
                    rtb_logger.AppendText(ToAppend);
                    if (ToAppend.Contains("Alert -"))
                    {
                        rtb_logger.SelectionStart = length;
                        rtb_logger.SelectionLength = ToAppend.Length;
                        rtb_logger.SelectionColor = Color.Red;
                    }
                    rtb_logger.AppendText(Environment.NewLine);
                    rtb_logger.SelectionStart = rtb_logger.TextLength;
                    rtb_logger.ScrollToCaret();
                }
                EnableControls();
            }
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            EnableControls();
            fbd_scriptfolder.SelectedPath = @"E:\test trunk 2\trunk\Project\Script";
            this.MinimumSize = new System.Drawing.Size(543, 409);
        }

        private void btn_scriptfolders_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == fbd_scriptfolder.ShowDialog())
            {
                tbx_scriptfolder.Text = fbd_scriptfolder.SelectedPath;
            }
            EnableControls();
        }

        private void btn_listfiles_Click(object sender, EventArgs e)
        {
            clx_testcases.Items.Clear();
            handler = new FileHandler(tbx_scriptfolder.Text, tbx_filters.Text);
            handler.init();
            foreach (FileInfo file in handler.Files)
            {
                clx_testcases.Items.Add(file.Name);
            }
            SetAllCheckStatus(true);
            EnableControls();
            MyLogger.Log(String.Format("Listing files from \"{0}\" with extension filter \"{1}\".", tbx_scriptfolder.Text, tbx_filters.Text));
        }

        private void btn_testeexecute_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ofd_testexecute.ShowDialog())
            {
                tbx_testexecute.Text = ofd_testexecute.FileName;
            }
            EnableControls();
        }

        private void btn_projectsuite_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ofd_projectsuite.ShowDialog())
            {
                tbx_projectsuite.Text = ofd_projectsuite.FileName;
            }
            EnableControls();
        }

        private void btn_checkall_Click(object sender, EventArgs e)
        {
            SetAllCheckStatus(true);
        }

        private void btn_uncheckall_Click(object sender, EventArgs e)
        {
            SetAllCheckStatus(false);
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyLogger.LogAdded -= new EventHandler(MyLogger_LogAdded);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            MyLogger.ResetLog();
            rtb_logger.Clear();
            EnableControls();
            logindex = 0;
        }

        private void tbx_matchfrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (! System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9\b]"))
                e.Handled = true;
        }

        private void tbx_matchto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9\b]"))
                e.Handled = true;
        }

        private void tbx_matchfrom_KeyUp(object sender, KeyEventArgs e)
        {
            EnableControls();
        }

        private void tbx_matchto_KeyUp(object sender, KeyEventArgs e)
        {
            EnableControls();
        }

        private void btn_match_Click(object sender, EventArgs e)
        {
            string regexp = ".*(";
            regexp += MyRegeExp.GenerateRegExpForNumericRange(int.Parse(tbx_matchfrom.Text), int.Parse(tbx_matchto.Text));
            regexp += ").*";
            if (tbx_filters.Text != "")
            { 
                regexp += "(" + tbx_filters.Text.Replace("*", "\\") + ")";
            }
            int items = clx_testcases.Items.Count;
            int matches = 0;
            for (int i = 0; i < items; i++)
            {
                bool match = System.Text.RegularExpressions.Regex.IsMatch(clx_testcases.Items[i].ToString(), regexp);
                clx_testcases.SetItemChecked(i, match);
                if( true == match )
                {
                    matches++;
                }
            }
            MyLogger.Log(String.Format("Select Match: matched {0} / {1} units giving a match of {2:0.00}%.", matches, items, (float)(((float)matches / (float)items) * 100))); 
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            ProgressForm progressForm = new ProgressForm();
            progressForm.TestExecute = tbx_testexecute.Text;
            progressForm.ProjectSuite = tbx_projectsuite.Text;
            progressForm.Project = tbx_project.Text;
            progressForm.ScriptFiles = clx_testcases.CheckedItems.OfType<string>().ToArray();
            progressForm.Function = tbx_runmethod.Text;
            progressForm.ShowDialog();
        }

        private void tbx_project_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnableControls();
        }

        private void tbx_runmethod_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnableControls();
        }

       
    }
}
