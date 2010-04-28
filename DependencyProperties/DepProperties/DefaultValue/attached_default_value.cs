using System.Windows.Controls;
using NUnit.Framework;

namespace DepProperties.DefaultValue
{
    [TestFixture, RequiresSTA]
    public class attached_default_value
    {
        [Test]
        public void A_should_set_default_value()
        {
            var obj = new MyObjectWithDefaultValue();

            MyObjectWithDefaultValue.GetMyAttached(obj).ShouldBe("attached");
        }

        [Test]
        public void B_should_set_default_value_on_other_object()
        {
            var listBox = new ListBox();

            MyObjectWithDefaultValue.GetMyAttached(listBox).ShouldBe("attached");
        }

        [Test]
        public void C_default_value_is_same_instance()
        {
            var listBox = new ListBox();
            var textBox = new TextBox();

            var value1 = MyObjectWithDefaultValue.GetPerson(listBox);
            var value2 = MyObjectWithDefaultValue.GetPerson(textBox);

            value1.ShouldBeSameInstance(value2);
        }
    }
}