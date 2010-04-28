using System.Windows.Controls;
using NUnit.Framework;

namespace DepProperties.AttachedDepProperty
{
    [TestFixture, RequiresSTA]
    public class attached
    {
        [Test]
        public void A_should_have_set_property_in_xaml()
        {
            var control = new SetAttachedPropertyInXaml();

            Grid.GetRow(control.textBox).ShouldBe(1);
        }

        [Test]
        public void B_should_be_able_to_set_property_in_code()
        {
            var control = new SetAttachedPropertyInXaml();

            Grid.SetRow(control.textBox, 2);

            Grid.GetRow(control.textBox).ShouldBe(2);
        }

        [Test]
        public void C_should_be_able_to_get_value_using_GetValue()
        {
            var control = new SetAttachedPropertyInXaml();

            var value = control.textBox.GetValue(Grid.RowProperty);

            value.ShouldBe(1);
        }

        [Test]
        public void D_should_be_able_to_set_property_using_SetValue()
        {
            var control = new SetAttachedPropertyInXaml();

            control.textBox.SetValue(Grid.RowProperty, 2);

            Grid.GetRow(control.textBox).ShouldBe(2);
        }
    }
}