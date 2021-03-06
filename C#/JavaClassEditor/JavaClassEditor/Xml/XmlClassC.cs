﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace JavaClassEditor
{
    public class XmlClassC
    {

       private static XmlClassC instance;

       private XmlClassC() 
       {
           FileName = null;
       }

       public static XmlClassC Instance
       {
          get 
          {
             if (instance == null)
             {
                 instance = new XmlClassC();
             }
             return instance;
          }
       }

        public string FileName { set; get; }
        public ElementC rootElement = new ElementC();

        public bool Parse()
        {
            if (null == FileName) {
                return false;            
            }
            bool retValue = true;
            XmlDocument pReader = new XmlDocument();
            pReader.Load(FileName);
            XmlElement root = pReader.DocumentElement;
            retValue = rootElement.Parse(root);
            if (true == retValue)
            {
                rootElement.PopulateTreeNode();
            }
            return retValue;
        }

        public TreeNode GetTreeNode()
        {
            return rootElement.GetTreeNode();
        }

        public string DebugText()
        {
            return rootElement.DebugText(0);
        }

        public bool WriteToFile(ref StreamWriter writer)
        {
            bool retValue = true;
            writer.WriteLine("<classes>");
            foreach (ElementC child in rootElement.children)
            {
                child.WriteToFile(ref writer, 1);
            }
            writer.WriteLine("</classes>");
            return retValue;
        }

    }
}
