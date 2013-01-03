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
    public partial class DefaultElementUC : UserControl
    {

        ElementC element = null;

        public DefaultElementUC()
        {
            InitializeComponent();
        }

        public void AssignElement(ElementC pElement)
        {
            element = pElement;
        }

        private void DefaultElementUC_VisibleChanged(object sender, EventArgs e)
        {
            if (true == this.Visible)
            {
                if (null != element)
                {
                    tbx_name.Text = element.ElementName;
                    tbx_value.Text = (null == element.ElementValue) ? "undefined" : element.ElementValue;
                    VisibilityButtons(element.ElementName);
                    EnableButtons(element.ElementName);
                }
            }
        }

        private void VisibilityButtons(string elementName)
        {
            switch (elementName)
            {
                case "objectname":
                {
                    btn_edit.Visible = true;
                    btn_save.Visible = true;
                    btn_addparam.Visible = false;
                    break;
                }
                case "params":
                {
                    btn_edit.Visible = false;
                    btn_save.Visible = false;
                    btn_addparam.Visible = true;
                    break;
                }
                default:
                {
                    btn_edit.Visible = false;
                    btn_save.Visible = false;
                    btn_addparam.Visible = false;
                    break;
                }
            }
        }

        private void EnableButtons(string elementName)
        {
            switch (elementName)
            {
                case "objectname":
                {
                    btn_edit.Enabled = (null != element );
                    btn_save.Enabled = false;
                    tbx_name.Enabled = false;
                    tbx_value.Enabled = false;
                    break;
                }
                default:
                {
                    btn_edit.Enabled = false;
                    btn_save.Enabled = false;
                    break;
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            tbx_value.Enabled = (null != element);
            btn_edit.Enabled = false;
            btn_save.Enabled = (null != element);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tbx_value.Text != element.ElementValue)
            {
                element.ElementValue = tbx_value.Text;
                MyTreeViewControlC.UpdateElement();
            }
        }

        private void btn_addparam_Click(object sender, EventArgs e)
        {
            ParamElementC param = new ParamElementC();
            param.ElementName = "param";
            param.ElementValue = "tbd";
            param.AttributeType = ContextC.Instance.GetParamTypes()[0];
            param.Text = param.ElementName + " - " + param.ElementValue;
            element.children.Add(param);
            element.Nodes.Add(param);
            MyTreeViewControlC.AddElement(param);
            element = null;
        }

    }
}
