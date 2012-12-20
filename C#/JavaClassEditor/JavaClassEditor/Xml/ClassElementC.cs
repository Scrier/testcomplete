using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace JavaClassEditor
{
    public class ClassElementC : ElementC
    {

        public string NameSpace { get; set; }
        public string ClassName { get; set; }
        public int ID { get; set; }

        public ClassElementC()
        {
            NameSpace = null;
            ClassName = null;
            ID = 0;
        }

        public int GetID()
        {
            return ID;
        }

        override public bool Parse(XmlNode node)
        {
            bool retValue = base.Parse(node);
            if (true == retValue)
            {
                foreach (AttributeC attrib in attributes)
                {
                    if ("namespace" == attrib.Name)
                    {
                        NameSpace = attrib.Value;
                    }
                    else if ("classname" == attrib.Name)
                    {
                        ClassName = attrib.Value;
                    }
                    else if ("id" == attrib.Name)
                    {
                        ID = ContextC.Instance.GetClassID();
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
            retValue += " namespace=\"" + ((null == NameSpace) ? "undefined" : NameSpace) + "\"";
            retValue += " classname=\"" + ((null == ClassName) ? "undefined" : ClassName) + "\"";
            retValue += " id=\"" + ID + "\">" + Environment.NewLine;
            foreach (ElementC element in children)
            {
                retValue += element.DebugText(indent + 1);
            }
            for (int i = 0; i < indent; i++)
            {
                retValue += "\t";
            }
            retValue += "</" + ElementName + ">" + Environment.NewLine;
            return retValue;
        }

        override public TreeNode PopulateTreeNode()
        {
            this.Text = ElementName + " - " + ClassName;
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
