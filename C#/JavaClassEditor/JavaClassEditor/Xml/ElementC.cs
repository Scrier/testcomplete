﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.Windows.Forms;

namespace JavaClassEditor
{
    public class ElementC : TreeNode
    {
        public string ElementName {set;get;}
        public string ElementValue { set; get; }
        public ArrayList children = new ArrayList();
        public ArrayList attributes = new ArrayList();

        public ElementC()
        {
            this.ElementName = null;
            this.ElementValue = null;
        }

        virtual public bool Parse(XmlNode node)
        {
            bool retValue = true;
            ElementName = node.Name;
            if (null != node.FirstChild && XmlNodeType.Text == node.FirstChild.NodeType)
            {
                ElementValue = node.InnerText;
            }
            else
            {
                ElementValue = null;
            }
            if (null != node.Attributes)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    AttributeC attrib = new AttributeC();
                    attrib.Name = attribute.Name;
                    attrib.Value = attribute.Value;
                    attributes.Add(attrib);
                }
            }
            if (null != node.FirstChild && XmlNodeType.Element == node.FirstChild.NodeType)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (true == retValue)
                    {
                        ElementC child = ElementFactoryC.GetElement(childNode.Name);
                        retValue = child.Parse(childNode);
                        children.Add(child);
                    }
                }
            }
            return retValue;
        }

        virtual public string DebugText(int indent)
        { 
            string retValue = "";
            for (int i = 0; i < indent; i++)
            {
                retValue += "\t";
            }
            retValue += "<" + ElementName;
            foreach (AttributeC att in attributes)
            {
                retValue += " " + att.Name + "=\"" + att.Value + "\"";
            }
            retValue += ">" + Environment.NewLine;
            if (null != ElementValue)
            {
                for (int i = 0; i < indent; i++)
                {
                    retValue += "\t";
                }
                retValue += "\t";
                retValue += ElementValue;
                retValue += Environment.NewLine;
            }
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

        virtual public void Debug()
        {
            MessageBox.Show(ElementName, ( null == ElementValue ) ? "undefined" : ElementValue);
        }

        virtual public TreeNode PopulateTreeNode()
        {
            this.Text = ElementName;
            if (0 < children.Count)
            {
                foreach (ElementC element in children)
                {
                    this.Nodes.Add(element.PopulateTreeNode());
                }
            }
            return this;
        }

        virtual public bool ContainsElement(string elementName)
        {
            foreach (ElementC child in children)
            {
                if (elementName == child.ElementName)
                {
                    return true;
                }
            }
            return false;
        }

        virtual public TreeNode GetTreeNode()
        {
            return this;
        }

    }
}
