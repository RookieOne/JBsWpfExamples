using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MenuBuilderExample
{
    public class WpfMenu : IMenu
    {
        public WpfMenu(Menu menu)
        {
            _menu = menu;
        }

        readonly Menu _menu;

        public void Add(MyMenuInfo menuInfo, params string[] menuHeaders)
        {
            var headerStack = new Stack<string>(menuHeaders.Reverse());

            Add(_menu.Items, menuInfo, headerStack);
        }

        public void Remove(params string[] menuHeaders)
        {
            var headerStack = new Stack<string>(menuHeaders.Reverse());

            Remove(_menu.Items, headerStack);
        }

        void Remove(ItemCollection items, Stack<string> headers)
        {
            var header = headers.Pop();

            if (headers.Count == 0)
            {
                RemoveMenuItem(items, header);
            }
            else
            {
                var m = Find(items, header);
                Remove(m.Items, headers);
            }
        }

        void RemoveMenuItem(ItemCollection items, string header)
        {
            var m = Find(items, header);

            items.Remove(m);
        }

        void Add(ItemCollection items, MyMenuInfo menuInfo, Stack<string> headers)
        {
            var header = headers.Pop();

            if (headers.Count == 0)
            {
                AddMenuItem(items, header, menuInfo);
            }
            else
            {
                var menuItem = Find(items, header);

                if (menuItem == null)
                    menuItem = AddMenuItem(items, header, MyMenuInfo.Empty());

                Add(menuItem.Items, menuInfo, headers);
            }
        }

        MenuItem AddMenuItem(ItemCollection items, string header, MyMenuInfo menuInfo)
        {
            var menuItem = menuInfo.CreateMenuItem(header);
            items.Add(menuItem);

            return menuItem;
        }

        MenuItem Find(ItemCollection items, string header)
        {
            return items.Cast<MenuItem>()
                .FirstOrDefault(i => i.Header.ToString() == header);
        }
    }
}