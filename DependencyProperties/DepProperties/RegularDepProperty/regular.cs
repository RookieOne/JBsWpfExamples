using System.Windows.Controls;
using NUnit.Framework;

namespace DepProperties.RegularDepProperty
{
    [TestFixture, RequiresSTA]
    public class regular
    {
        [Test]
        public void A_should_have_set_property_in_xaml()
        {
            var control = new SetRegPropertyInXaml();

            control.textBox.Text.ShouldBe("Set in xaml");
        }

        [Test]
        public void B_should_be_able_to_set_property_in_code()
        {
            var control = new SetRegPropertyInXaml();

            control.textBox.Text = "Set in code";

            control.textBox.Text.ShouldBe("Set in code");
        }

        [Test]
        public void C_should_be_able_to_get_value_using_GetValue()
        {
            var control = new SetRegPropertyInXaml();

            var value = control.textBox.GetValue(TextBox.TextProperty).ToString();

            value.ShouldBe("Set in xaml");
        }

        [Test]
        public void D_should_be_able_to_set_property_using_SetValue()
        {
            var control = new SetRegPropertyInXaml();

            control.textBox.SetValue(TextBox.TextProperty, "Set with SetValue");

            control.textBox.Text.ShouldBe("Set with SetValue");
        }

        [Test]
        public void E_should_be_able_to_set_property_on_diff_object()
        {
            var listBox = new ListBox();

            listBox.SetValue(TextBox.TextProperty, "test");

            listBox.GetValue(TextBox.TextProperty).ToString().ShouldBe("test");
        }
    }
}