using NUnit.Framework;

namespace DepProperties
{
    public static class AssertExtensions
    {
        public static void ShouldBe<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void ShouldBeSameInstance(this object actual, object expected)
        {
            Assert.AreSame(expected, actual);
        }
    }
}