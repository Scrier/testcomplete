﻿using System;
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
                cbx_type.SelectedItem = Element.AttributeType;
                tbx_name.Text = Element.ElementValue;
                tbx_init.Text = ((null == Element.InitType) ? "" : Element.InitType);
                tbx_description.Text = ((null == Element.CommentType) ? "" : Element.CommentType);
            }
        }

        private void EnableButtons()
        {
            cbx_init.Checked = ((null == Element) ? false : (Element.InitType != null));
            cbx_description.Checked = ((null == Element) ? false : (Element.CommentType != null));
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

    }
}
