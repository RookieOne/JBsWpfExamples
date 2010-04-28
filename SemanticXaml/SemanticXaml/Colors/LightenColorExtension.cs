using System.Windows.Media;

namespace SemanticXaml.Colors
{
    public static class LightenColorExtension
    {
        /// <summary>
        ///   This method applies lighting to a color.
        ///   For instance, a color that has a lighting factor of 1 applies, appears at its original value.
        ///   A color with a lighting factor of 0.5 appears only half as bright as it was before.
        ///   A color with a lighting factor of 1.5 appears roughly twice as bright as before.
        ///   A color with a lightning factor of 2 appears white.
        /// </summary>
        /// <param name="originalColor">Base color</param>
        /// <param name="lightFactor">
        ///   Amount of light applied to the color
        /// </param>
        /// <returns>Lit color</returns>
        /// <remarks>
        ///   This routine is very fast. Even when using it in tight loops, I (Markus) have not been able to 
        ///   meassure a significant amount of time spent in this routine (always less than 1ms). I was originally
        ///   concerened about the performance of this, so I added a caching mechanism, but that slowed things down
        ///   by 2 orders of magnitude.
        /// </remarks>
        public static Color Lighten(this Color originalColor, float lightFactor)
        {
            if (TransformationNotNeeded(lightFactor))
                return originalColor;

            if (RealBright(lightFactor))
                return System.Windows.Media.Colors.White;

            if (ShouldDarken(lightFactor))
                return DarkenColor(originalColor, lightFactor);

            return LightenColor(originalColor, lightFactor);
        }

        static bool TransformationNotNeeded(float lightFactor)
        {
            var value = lightFactor - 1.0f;

            return value < 0.01f
                   && value > -0.01f;
        }

        static bool RealBright(float lightFactor)
        {
            return lightFactor >= 2.0f;
        }

        static bool ShouldDarken(float lightFactor)
        {
            return lightFactor < 1.0f;
        }

        static Color DarkenColor(Color color, float lightFactor)
        {
            var red = (byte) (color.R*lightFactor);
            var green = (byte) (color.G*lightFactor);
            var blue = (byte) (color.B*lightFactor);

            return Color.FromRgb(red, green, blue);
        }

        static Color LightenColor(Color color, float lightFactor)
        {
            // Lighten
            // We do this by approaching 256 for a light factor of 2.0f
            float fFactor2 = lightFactor;
            if (fFactor2 > 1.0f)
            {
                fFactor2 -= 1.0f;
            }

            var red = LightenColorComponent(color.R, fFactor2);
            var green = LightenColorComponent(color.G, fFactor2);
            var blue = LightenColorComponent(color.B, fFactor2);

            return Color.FromRgb(red, green, blue);
        }

        static byte LightenColorComponent(byte colorComponent, float fFactor)
        {
            var inverse = 255 - colorComponent;
            colorComponent += (byte) (inverse*fFactor);

            return colorComponent < 255
                       ? colorComponent
                       : (byte) 255;
        }
    }
}