using NUnit.Framework;

namespace MenuBuilderExample.Test
{
    [TestFixture]
    public class MenuBuilderTest
    {
        [Test]
        public void TestOne()
        {
            var menuBuilder = new MenuBuilder();

            var menu = menuBuilder.GetMenu();

            Assert.IsNotNull(menu);
        }
    }
}