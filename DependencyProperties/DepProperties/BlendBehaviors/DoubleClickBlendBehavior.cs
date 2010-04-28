using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace DepProperties.BlendBehaviors
{
    public class DoubleClickBlendBehavior : Behavior<Control>
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof (ICommand), typeof (DoubleClickBlendBehavior), null);

        [Category("Command")]
        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseDoubleClick += (sender, args) =>
                                                     {
                                                         if (Command == null)
                                                             return;
                                                         if (Command.CanExecute(null))
                                                             Command.Execute(null);
                                                     };
        }
    }
}