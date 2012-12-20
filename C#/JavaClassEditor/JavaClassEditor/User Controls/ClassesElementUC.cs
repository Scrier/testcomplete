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
    public partial class ClassesElementUC : UserControl
    {

        private ElementC pElement = null;

        public ClassesElementUC()
        {
            InitializeComponent();
            btn_new_class.Enabled = false;
        }

        public void SetSelectedElement(ElementC element)
        {
            pElement = element;
            btn_new_class.Enabled = true;
        }

        private void btn_new_class_Click(object sender, EventArgs e)
        {
            ClassElementC element = new ClassElementC();
            element.ElementName = "class";
            element.ClassName = "tbd";
            element.NameSpace = "tbd";
            element.Text = "class - tbd";
            element.ID = ContextC.Instance.GetClassID();
            pElement.children.Add(element);
            pElement.Nodes.Add(element);
            MyTreeViewControlC.AddElement(element);
            MyLoggerC.Log("Created a new class element.");
        }
    }
}
