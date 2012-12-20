using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JavaClassEditor.User_Controls
{
    public partial class ClassElementUC : UserControl
    {

        private ClassElementC Element;

        public ClassElementUC()
        {
            InitializeComponent();
            Element = null;
        }

        public void SetElement(ClassElementC element)
        {
            Element = element;
            if (null != Element)
            {
                tbx_id.Text = Element.ID.ToString();
                tbx_namespace.Text = Element.NameSpace;
                tbx_class.Text = Element.ClassName;
                if ("tbd" == Element.ClassName &&
                    "tbd" == Element.NameSpace)
                {
                    btn_edit.Enabled = false;
                    btn_save.Enabled = true;
                    tbx_class.Enabled = true;
                    tbx_namespace.Enabled = true;
                }
                else
                {
                    btn_edit.Enabled = true;
                    btn_save.Enabled = false;
                    tbx_class.Enabled = false;
                    tbx_namespace.Enabled = false;
                }
                EnableButtons();
            }
        }

        private void ClassElementUC_Load(object sender, EventArgs e)
        {
            btn_edit.Enabled = true;
            btn_save.Enabled = false;
            tbx_class.Enabled = false;
            tbx_id.Enabled = false;
            tbx_namespace.Enabled = false;
            EnableButtons();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            tbx_class.Enabled = true;
            tbx_namespace.Enabled = true;
            btn_edit.Enabled = false;
            btn_save.Enabled = true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            tbx_class.Enabled = false;
            tbx_namespace.Enabled = false;
            btn_edit.Enabled = true;
            btn_save.Enabled = false;
            if (Element.NameSpace != tbx_namespace.Text)
            {
                Element.NameSpace = tbx_namespace.Text;
            }
            if (Element.ClassName != tbx_class.Text)
            {
                Element.ClassName = tbx_class.Text;
            }
            Element.Text = Element.ElementName + " - " + Element.ClassName;
            Element = null;
        }

        private void btn_add_objectname_Click(object sender, EventArgs e)
        {
            AddElement("objectname", CapitalLetter(Element.ClassName));
        }

        private void btn_add_constructor_Click(object sender, EventArgs e)
        {
            AddElement("constructor");
        }

        private void btn_add_init_Click(object sender, EventArgs e)
        {
            AddElement("init");
        }

        private void btn_add_params_Click(object sender, EventArgs e)
        {
            AddElement("params");
        }

        private void AddElement(string name, string value = "")
        {
            ElementC element = new ElementC();
            element.ElementName = name;
            if ("" != value)
            {
                element.ElementValue = value;
            }
            element.Text = element.ElementName;
            Element.children.Add(element);
            Element.Nodes.Add(element);
            MyTreeViewControlC.AddElement(element);
        }

        private void EnableButtons()
        {
            btn_add_objectname.Enabled = (null == Element) ? false : !Element.ContainsElement("objectname");
            btn_add_init.Enabled = (null == Element) ? false : !Element.ContainsElement("init");
            btn_add_constructor.Enabled = (null == Element) ? false : !Element.ContainsElement("constructor");
            btn_add_params.Enabled = (null == Element) ? false : !Element.ContainsElement("params");
        }

        private string CapitalLetter(string input)
        {
            if (input.Length < 1)
            {
                return string.Empty;
            }
            else if (input.Length > 1)
            {
                return (input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower());
            }
            else
            {
                return input.ToUpper();
            }
        }

    }
}
