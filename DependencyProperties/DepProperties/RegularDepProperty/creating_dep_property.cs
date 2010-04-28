using System.Windows.Controls;
using NUnit.Framework;

namespace DepProperties.RegularDepProperty
{
    [TestFixture, RequiresSTA]
    public class creating_dep_property
    {
        [Test]
        public void A_should_be_able_to_set_property_in_code()
        {
            var obj = new MyDependencyObject();

            obj.MyText = "Set in code";

            obj.MyText.ShouldBe("Set in code");
        }

        [Test]
        public void B_should_be_able_to_get_value_using_GetValue()
        {
            var obj = new MyDependencyObject();

            obj.MyText = "test";

            var value = obj.GetValue(MyDependencyObject.MyTextProperty).ToString();

            value.ShouldBe("test");
        }

        [Test]
        public void C_should_be_able_to_set_property_using_SetValue()
        {
            var obj = new MyDependencyObject();

            obj.SetValue(MyDependencyObject.MyTextProperty, "Set with SetValue");

            obj.MyText.ShouldBe("Set with SetValue");
        }

        [Test]
        public void D_should_be_able_to_set_property_on_diff_object()
        {
            var listBox = new ListBox();

            listBox.SetValue(MyDependencyObject.MyTextProperty, "test");

            listBox.GetValue(MyDependencyObject.MyTextProperty).ToString().ShouldBe("test");
        }
    }
}