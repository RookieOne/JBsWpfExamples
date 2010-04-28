using System.Windows.Media;

namespace SemanticXaml.Colors
{
    public static class InverseColorExtensions
    {
        public static Color GetInverse(this Color color)
        {
            var inverse = new Color
                              {
                                  A = color.A,
                                  R = GetInverseOfColor(color.R),
                                  G = GetInverseOfColor(color.G),
                                  B = GetInverseOfColor(color.B)
                              };

            return inverse;
        }

        static byte GetInverseOfColor(byte colorComponent)
        {
            return (byte) (colorComponent ^ 0xFF);
        }
    }
}