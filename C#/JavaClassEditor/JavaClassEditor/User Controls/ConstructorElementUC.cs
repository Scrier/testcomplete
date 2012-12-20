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
    public partial class ConstructorElementUC : UserControl
    {

        private ElementC Element;

        public ConstructorElementUC()
        {
            InitializeComponent();
            Element = null;
            EnableButtons();
        }

        public void SetElement(ElementC element)
        {
            Element = element;
            EnableButtons();
        }

        private void btn_add_param_Click(object sender, EventArgs e)
        {
            ParamElementC element = new ParamElementC();
            element.ElementName = "param";
            element.ElementValue = "tbd";
            element.AttributeType = ContextC.Instance.GetParamTypes()[0];
            element.Text = element.ElementName + " - " + element.ElementValue;
            Element.children.Add(element);
            Element.Nodes.Add(element);
            MyTreeViewControlC.AddElement(element);
            Element = null;
        }

        private void EnableButtons()
        {
            btn_add_param.Enabled = (null != Element);
        }
    }
}
