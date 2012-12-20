using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JavaClassEditor
{
    public class ObjectNameElementC : ElementC
    {

        public ObjectNameElementC()
        { 
        
        }

        override public bool Parse(XmlNode node)
        {
            bool retValue = base.Parse(node);
            return retValue;
        }

        override public string DebugText(int indent)
        {
            string retValue = "";
            for (int i = 0; i < indent; i++)
            {
                retValue += "\t";
            }
            retValue += "<" + ElementName + ">" + ElementValue + "</" + ElementName + ">" + Environment.NewLine;
            return retValue;
        }

    }
}
