using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DepProperties.Behaviors
{
    public static class DoubleClickCommandBehavior
    {
        static DoubleClickCommandBehavior()
        {
            CommandProperty = DependencyProperty.RegisterAttached("Command",
                                                                  typeof (ICommand),
                                                                  typeof (DoubleClickCommandBehavior),
                                                                  new PropertyMetadata(OnCommandChanged));
        }

        public static readonly DependencyProperty CommandProperty;

        public static ICommand GetCommand(DependencyObject o)
        {
            return (ICommand) o.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(CommandProperty, value);
        }

        static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Control;

            if (control == null)
                return;

            control.MouseDoubleClick += (sender, args) =>
                                            {
                                                var command = GetCommand(d);
                                                if (command == null)
                                                    return;
                                                if (command.CanExecute(null))
                                                    command.Execute(null);
                                            };
        }
    }
}