using System.Windows.Controls;
using System.Windows.Input;
using NUnit.Framework;

namespace DepProperties.Behaviors
{
    [TestFixture, RequiresSTA]
    public class double_click_behavior
    {
        [Test]
        public void should_execute_command()
        {
            bool commandExecuted = false;

            var command = new ActionCommand(() => commandExecuted = true);

            var listBox = new ListBox();

            DoubleClickCommandBehavior.SetCommand(listBox, command);

            var e = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            e.RoutedEvent = Control.MouseDoubleClickEvent;

            listBox.RaiseEvent(e);

            commandExecuted.ShouldBe(true);
        }
    }
}