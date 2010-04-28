using System.Windows.Controls;
using NUnit.Framework;

namespace DepProperties.DefaultValue
{
    [TestFixture, RequiresSTA]
    public class default_value
    {
        [Test]
        public void A_should_have_set_default_value()
        {
            var obj = new MyObjectWithDefaultValue();

            obj.MyText.ShouldBe("default");
        }

        [Test]
        public void B_should_return_default_from_GetValue()
        {
            var listBox = new ListBox();

            listBox.GetValue(MyObjectWithDefaultValue.MyTextProperty).ToString().ShouldBe("default");
        }
    }
}