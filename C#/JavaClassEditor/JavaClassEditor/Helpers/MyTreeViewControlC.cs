using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaClassEditor
{
    public static class MyTreeViewControlC
    {

        public static event EventHandler ElementAdded;
        public static event EventHandler ElementUpdated;

        private static List<ElementC> elements = new List<ElementC>();

        public static void AddElement(ElementC element)
        {
            elements.Add(element);

            if (ElementAdded != null)
            {
                ElementAdded(null, EventArgs.Empty);
            }
        }

        public static void UpdateElement()
        {
            if (ElementUpdated != null)
            {
                ElementUpdated(null, EventArgs.Empty);
            }
        }

        public static ElementC GetLastElement()
        {
            if (elements.Count > 0)
            {
                return elements[elements.Count - 1];
            }
            else
            {
                return null;
            }
        }

    }
}
