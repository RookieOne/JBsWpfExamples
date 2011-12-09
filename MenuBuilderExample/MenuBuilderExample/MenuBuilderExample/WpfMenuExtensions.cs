using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuBuilderExample
{
    public static class WpfMenuExtensions
    {
        public static void Add(this WpfMenu menu, Action action, params string[] menuHeaders)
        {
            menu.Add(new MyMenuInfo(action), menuHeaders);
        }
    }
}
