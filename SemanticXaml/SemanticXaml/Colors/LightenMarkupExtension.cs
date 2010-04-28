using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace SemanticXaml.Colors
{
    public class LightenMarkupExtension : MarkupExtension
    {
        public Color Color { get; set; }

        public float LightFactor { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Color.Lighten(LightFactor);
        }
    }
}