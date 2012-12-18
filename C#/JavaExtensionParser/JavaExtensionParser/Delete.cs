using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JavaExtensionParser
{
    public partial class Delete : Form
    {
        DirectoryInfo[] dirs = null;

        public Delete(DirectoryInfo[] DI)
        {
            InitializeComponent();
            dirs = DI;
            rtb_files.Clear();
            string currDir = Directory.GetCurrentDirectory();
            foreach (DirectoryInfo D1 in dirs)
            {
                foreach (FileInfo file in D1.GetFiles("*.old"))
                {
                    rtb_files.AppendText(file.FullName.Substring(currDir.Length, file.FullName.Length - currDir.Length) + Environment.NewLine);
                }
            }
        }

        public void ClearFiles()
        {
            foreach (DirectoryInfo D1 in dirs)
            {
                foreach (FileInfo file in D1.GetFiles("*.old"))
                {
                    file.Delete();
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            ClearFiles();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
