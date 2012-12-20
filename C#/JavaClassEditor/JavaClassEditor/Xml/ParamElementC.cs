using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace JavaClassEditor
{
    public class ParamElementC : ElementC
    {

        public string AttributeType { get; set; }
        public string InitType { get; set; }
        public string CommentType { get; set; }
        public string ClassKeyType { get; set; }
        public string IdType { get; set; }
        public string Array { get; set; }
        public string Validate { get; set; }

        public ParamElementC()
        {
            AttributeType = null;
            InitType = null;
            CommentType = null;
            ClassKeyType = null;
            IdType = null;
            Array = null;
        }

        override public bool Parse(XmlNode node)
        {
            bool retValue = base.Parse(node);
            if (true == retValue)
            {
                foreach (AttributeC attrib in attributes)
                {
                    if ("type" == attrib.Name)
                    {
                        AttributeType = attrib.Value;
                    }
                    else if ("init" == attrib.Name)
                    {
                        InitType = attrib.Value;
                    }
                    else if ("comment" == attrib.Name)
                    {
                        CommentType = attrib.Value;
                    }
                    else if ("classkey" == attrib.Name)
                    {
                        ClassKeyType = attrib.Value;
                    }
                    else if ("id" == attrib.Name)
                    {
                        IdType = attrib.Value;
                    }
                    else if ("array" == attrib.Name)
                    {
                        Array = attrib.Value;
                    }
                    else if ("validate" == attrib.Name)
                    {
                        Validate = attrib.Value;
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
            if( null != AttributeType )
            {
                retValue += " type=\"" + AttributeType + "\"";
            }
            if (null != CommentType)
            {
                retValue += " comment=\"" + CommentType + "\"";
            }
            if (null != ClassKeyType)
            {
                retValue += " classkey=\"" + ClassKeyType + "\"";
            }
            if (null != InitType)
            {
                retValue += " init=\"" + InitType + "\"";
            }
            if (null != IdType)
            {
                retValue += " id=\"" + IdType + "\"";
            }
            if (null != Array)
            {
                retValue += " array=\"" + Array + "\"";
            }
            if (null != Validate)
            {
                retValue += " validate=\"" + Validate + "\"";
            }
            retValue += ">" + ElementValue + "</" + ElementName + ">" + Environment.NewLine;
            return retValue;
        }

        override public TreeNode PopulateTreeNode()
        {
            this.Text = ElementName + " - " + ElementValue;
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
