using System.Windows.Controls;
using System.Windows.Documents;
using NUnit.Framework;

namespace DepProperties.Inherits
{
    [TestFixture, RequiresSTA]
    public class inheritable
    {
        [Test]
        public void A_should_inherit_property()
        {
            var stackPanel = new StackPanel();
            var textBox = new TextBox();

            stackPanel.Children.Add(textBox);

            TextElement.SetFontSize(stackPanel, 26);

            TextElement.GetFontSize(textBox).ShouldBe(26);
        }

        [Test]
        public void B_should_inherit_my_property()
        {
            var stackPanel = new StackPanel();
            var textBox = new TextBox();

            stackPanel.Children.Add(textBox);

            MyInheritablePropertyOwner.SetInheritable(stackPanel, "test");

            MyInheritablePropertyOwner.GetInheritable(textBox).ShouldBe("test");
        }
    }
}