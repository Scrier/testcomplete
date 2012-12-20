using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace JavaClassEditor
{
    public class MethodElementC : ElementC
    {

        public string AttributeName { get; set; }
        public string AssignTo { get; set; }

        public MethodElementC()
        {
            AttributeName = null;
            AssignTo = null;
        }

        override public bool Parse(XmlNode node)
        {
            bool retValue = base.Parse(node);
            if (true == retValue)
            {
                foreach (AttributeC attrib in attributes)
                {
                    if ("name" == attrib.Name)
                    {
                        AttributeName = attrib.Value;
                    }
                    else if ("assignTo" == attrib.Name)
                    {
                        AssignTo = attrib.Value;
                    }
                    else
                    {
                        MyLoggerC.Log("Unknown attribute named " + attrib.Name + " for element " + ElementName + ".");
                        retValue = false;
                        break;
                    }
                }
            }
            return retValue;
        }

        override public string DebugText(int indent)
        {
            string retValue = "";
            for (int i = 0; i < indent; i++)
            {
                retValue += "\t";
            }
            retValue += "<" + ElementName;
            retValue += " name=\"" + ((AttributeName == null) ? "undefined" : AttributeName) + "\"";
            if (null != AssignTo)
            {
                retValue += " assignTo=\"" + AssignTo + "\"";
            }
            retValue += "> " + Environment.NewLine;
            foreach (ElementC element in children)
            {
                retValue += element.DebugText(indent + 1);
            }
            for (int i = 0; i < indent; i++)
            {
                retValue += "\t";
            }
            retValue += ElementValue + "</" + ElementName + ">" + Environment.NewLine;
            return retValue;
        }

        override public TreeNode PopulateTreeNode()
        {
            this.Text = ElementName + " - " + AttributeName;
            if (0 < children.Count)
            {
                foreach (ElementC element in children)
                {
                    this.Nodes.Add(element.PopulateTreeNode());
                }
            }
            return this;
        }

    }
}
