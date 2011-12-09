using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace MenuBuilderExample
{

    public class MyMenuInfo
    {
        public MyMenuInfo(Action action)
        {
            this.Command = new DelegateCommand(action);
        }

        public ICommand Command { get; set; }
        public string Icon { get; set; }

        public MenuItem CreateMenuItem(string header)
        {
            var menuItem = new MenuItem();
            menuItem.Header = header;
            menuItem.Command = Command;
            menuItem.Icon = Icon;

            return menuItem;
        }

        public static MyMenuInfo Empty()
        {
            return new MyMenuInfo(() => { });
        }

    }

    public interface IMenu
    {
        void Add(MyMenuInfo menuInfo, params string[] menuHeaders);
        void Remove(params string[] menuHeaders);
    }
}