using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaClassEditor
{
    public class ContextC
    {

        private int ClassID;

        private static ContextC instance = null;

        private ContextC()
        {
            ClassID = 1;
        }

        public static ContextC Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContextC();
                }
                return instance;
            }
        }

        public void ResetClassID()
        {
            ClassID = 1;
        }

        public int GetClassID()
        {
            return ClassID++;
        }

        public List<string> GetParamTypes()
        {
            List<string> retValue = new List<string>();
            retValue.Add("int");
            retValue.Add("float");
            retValue.Add("string");
            retValue.AddRange(PopulateStringList(XmlClassC.Instance.rootElement));
            return retValue;
        }

        private List<string> PopulateStringList(ElementC element)
        {
            List<string> retValue = new List<string>();
            foreach ( ElementC c in element.children )
            {
                if ("class" == c.ElementName)
                {
                    ClassElementC param = (ClassElementC)c;
                    retValue.Add(param.NameSpace + "." + param.ClassName);
                }
                if (c.children.Count > 0)
                {
                    retValue.AddRange(PopulateStringList(c));
                }
            }
            return retValue;
        }

    }
}
