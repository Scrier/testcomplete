using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JavaClassEditor
{
    public partial class ParamElementUC : UserControl
    {

        private ParamElementC Element;

        public ParamElementUC()
        {
            InitializeComponent();
            Element = null;
        }

        public void SetElement(ParamElementC element)
        {
            Element = element;
            PopulateData();
            EnableButtons();
            EnableControls();
        }

        private void PopulateData()
        {
            if (null != Element)
            {
                tbx_element.Text = Element.ElementName;
                cbx_type.Items.Clear();
                List<string> types = ContextC.Instance.GetParamTypes();
                foreach (string str in types)
                {
                    cbx_type.Items.Add(str);
                }
                cbx_type.SelectedItem = ( null == Element.AttributeType ) ? "undefined" : Element.AttributeType;
                tbx_name.Text = Element.ElementValue;
                tbx_init.Text = ((null == Element.InitType) ? "" : Element.InitType);
                tbx_description.Text = ((null == Element.CommentType) ? "" : Element.CommentType);
            }
        }

        private void EnableButtons()
        {
            cbx_init.Checked = ((null == Element) ? false : (Element.InitType != null));
            cbx_description.Checked = ((null == Element) ? false : (Element.CommentType != null));
            cbx_classkey.Checked = ((null == Element) ? false : (Element.ClassKeyType != null && Element.ClassKeyType == "yes"));
            cbx_array.Checked = ((null == Element) ? false : (Element.Array != null && Element.Array == "yes"));
            cbx_classkey.Enabled = !cbx_classkey.Checked;
        }

        private void EnableControls()
        {
            tbx_element.Enabled = false;
            tbx_init.Enabled = (( null == Element) ? false : ( Element.InitType != null ) );
            tbx_description.Enabled = ((null == Element) ? false : (Element.CommentType != null));
        }

        private void cbx_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Element.AttributeType = cbx_type.SelectedItem.ToString();
        }

        private void cbx_init_CheckedChanged(object sender, EventArgs e)
        {
            tbx_init.Enabled = cbx_init.Checked;
        }

        private void cbx_description_CheckedChanged(object sender, EventArgs e)
        {
            tbx_description.Enabled = cbx_description.Checked;
        }

        private void ParamElementUC_Load(object sender, EventArgs e)
        {
            ttp_info_tooltip.SetToolTip(this.cbx_classkey, "Class key is used to identify a specified class by string value, this should never be changed");
        }

        private void cbx_classkey_CheckedChanged(object sender, EventArgs e)
        {
            if (true == cbx_classkey.Checked)
            {
                ElementC parent = (ElementC)Element.Parent;
                foreach (ElementC child in parent.children )
                {
                    ParamElementC cast = (ParamElementC)child;
                    if (null != cast.ClassKeyType && "yes" == cast.ClassKeyType && Element.ElementValue != cast.ElementValue )
                    {
                        cast.ClassKeyType = null;
                        MyLoggerC.Log("Moved classkey from parameter \"" + cast.ElementValue + "\" to parameter \"" + Element.ElementValue + "\"." + Environment.NewLine);
                    }
                }
                Element.ClassKeyType = "yes";
                cbx_classkey.Enabled = false;
            }
            else
            {
                Element.ClassKeyType = null;
            }
        }

        private void cbx_array_CheckedChanged(object sender, EventArgs e)
        {
            if (true == cbx_array.Checked)
            {
                Element.Array = "yes";
            }
            else
            {
                Element.Array = null;
            }
        }

    }
}
