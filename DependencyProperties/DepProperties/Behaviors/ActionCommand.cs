using System;
using System.Windows.Input;

namespace DepProperties.Behaviors
{
    public class ActionCommand : ICommand
    {
        public ActionCommand(Action action)
        {
            _action = action;
        }

        readonly Action _action;

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}