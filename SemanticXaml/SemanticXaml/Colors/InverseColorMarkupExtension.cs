using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace SemanticXaml.Colors
{
    public class InverseColorMarkupExtension : MarkupExtension
    {
        public Color Of { get; set; }
        public string As { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            Color colorToInverse = Of;

            var inverse = colorToInverse.GetInverse();

            if (As == "Brush")
                return new SolidColorBrush(inverse);

            return inverse;
        }
    }
}