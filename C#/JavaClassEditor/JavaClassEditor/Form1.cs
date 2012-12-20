using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JavaClassEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyLoggerC.LogAdded += new EventHandler(MyLoggerC_LogAdded);
            MyTreeViewControlC.ElementAdded += new EventHandler(MyTreeViewControl_ElementAdded);
            MyTreeViewControlC.ElementUpdated += new EventHandler(MyTreeViewControl_ElementUpdated);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            XmlClassC.Instance.FileName = openFileDialog1.FileName;
            ContextC.Instance.ResetClassID();
            if (true != XmlClassC.Instance.Parse())
            {
                //rtb_debug.Text = XmlClassC.Instance.DebugText();
                MyLoggerC.Log("Unable to parse file " + openFileDialog1.FileName + ".");
            }
            else
            {
                MyLoggerC.Log("File \"" + openFileDialog1.FileName + "\" opened.");
            }
            tvw_treeview.Nodes.Add(XmlClassC.Instance.GetTreeNode());
        }

        private void MyLoggerC_LogAdded(object sender, EventArgs e)
        {
            int length = rtb_debug.TextLength;  // at end of text
            string ToAppend = MyLoggerC.GetLastLog();
            rtb_debug.AppendText(ToAppend);
            if (ToAppend.Contains("Alert -"))
            {
                rtb_debug.SelectionStart = length;
                rtb_debug.SelectionLength = ToAppend.Length;
                rtb_debug.SelectionColor = Color.Red;
            }
        }

        private void MyTreeViewControl_ElementAdded(object sender, EventArgs e)
        {
            ElementC element = MyTreeViewControlC.GetLastElement();
            if (null != element)
            {
                tvw_treeview.SelectedNode = element;
                tvw_treeview.Select();
            }
        }

        private void MyTreeViewControl_ElementUpdated(object sender, EventArgs e)
        {
            ElementC temp = (ElementC)tvw_treeview.SelectedNode;
            switch (temp.ElementName)
            {
                case "class":
                {
                    uc_class.SetElement((ClassElementC)temp);
                    break;
                }
                case "objectname":
                {
                    uc_default.Visible = false;
                    uc_default.AssignElement(temp);
                    uc_default.Visible = true;
                    break;
                }
                case "constructor":
                {
                    uc_constructor.SetElement(temp);
                    uc_constructor.Visible = true;
                    break;
                }
                case "param":
                {
                    uc_param.SetElement((ParamElementC)temp);
                    uc_param.Visible = true;
                    break;
                }
                default:
                {

                    break;
                }
            }
            tvw_treeview.Focus();
        }

        private void tvw_treeview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ElementC temp = (ElementC)tvw_treeview.SelectedNode;
            DisableUserControls();
            switch (temp.ElementName)
            {
                case "classes":
                {
                    uc_classes.SetSelectedElement(temp);
                    uc_classes.Visible = true;
                    break;
                }
                case "class":
                {
                    uc_class.SetElement((ClassElementC)temp);
                    uc_class.Visible = true;
                    break;
                }
                case "constructor":
                {
                    uc_constructor.SetElement(temp);
                    uc_constructor.Visible = true;
                    break;
                }
                case "param":
                {
                    uc_param.SetElement((ParamElementC)temp);
                    uc_param.Visible = true;
                    break;
                }
                default:
                {
                    uc_default.AssignElement(temp);
                    uc_default.Visible = true;
                    break;
                }
            }
        }

        private void DisableUserControls()
        {
            uc_default.Visible = false;
            uc_classes.Visible = false;
            uc_class.Visible = false;
            uc_constructor.Visible = false;
            uc_param.Visible = false;
        }

    }
}
