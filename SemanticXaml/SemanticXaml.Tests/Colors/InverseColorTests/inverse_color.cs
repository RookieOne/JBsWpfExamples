using System.Windows.Media;
using NUnit.Framework;
using SemanticXaml.Colors;

namespace SemanticXaml.Tests.Colors.InverseColorTests
{
    [TestFixture]
    public class inverse_color
    {
        [Test]
        public void inverse_test1()
        {
            var originalColor = Color.FromArgb(255, 50, 50, 50);
            var inverseColor = originalColor.GetInverse();

            inverseColor.A.ShouldBe<byte>(255);
            inverseColor.R.ShouldBe<byte>(205);
            inverseColor.G.ShouldBe<byte>(205);
            inverseColor.B.ShouldBe<byte>(205);
        }

        [Test]
        public void inverse_test2()
        {
            var originalColor = Color.FromArgb(255, 0, 100, 150);
            var inverseColor = originalColor.GetInverse();

            inverseColor.A.ShouldBe<byte>(255);
            inverseColor.R.ShouldBe<byte>(255);
            inverseColor.G.ShouldBe<byte>(155);
            inverseColor.B.ShouldBe<byte>(105);
        }

        [Test]
        public void inverse_test3()
        {
            var originalColor = Color.FromArgb(255, 255, 0, 100);
            var inverseColor = originalColor.GetInverse();

            inverseColor.A.ShouldBe<byte>(255);
            inverseColor.R.ShouldBe<byte>(0);
            inverseColor.G.ShouldBe<byte>(255);
            inverseColor.B.ShouldBe<byte>(155);
        }
    }
}