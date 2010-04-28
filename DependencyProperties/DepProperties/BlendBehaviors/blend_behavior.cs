using System.Windows.Controls;
using System.Windows.Input;
using DepProperties.Behaviors;
using NUnit.Framework;

namespace DepProperties.BlendBehaviors
{
    [TestFixture, RequiresSTA]
    public class blend_behavior
    {
        [Test]
        public void should_execute_command()
        {
            bool executed = false;
            var command = new ActionCommand(() => executed = true);

            var listBox = new ListBox();

            var behavior = new DoubleClickBlendBehavior();
            behavior.Command = command;
            behavior.Attach(listBox);

            var e = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            e.RoutedEvent = Control.MouseDoubleClickEvent;

            listBox.RaiseEvent(e);

            executed.ShouldBe(true);
        }
    }
}