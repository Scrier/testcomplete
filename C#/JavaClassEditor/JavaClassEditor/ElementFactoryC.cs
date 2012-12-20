using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaClassEditor
{
    public static class ElementFactoryC
    {

        public static ElementC GetElement(string name)
        {
            switch (name)
            {
                case "method":
                {
                    return new MethodElementC();
                }
                case "objectname":
                {
                    return new ObjectNameElementC();
                }
                case "class":
                {
                    return new ClassElementC();
                }
                case "param":
                {
                    return new ParamElementC();    
                }
                default:
                {
                    return new ElementC();    
                }
            }
        }

    }
}
