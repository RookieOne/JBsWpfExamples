using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using SemanticXaml.Extensions;

namespace SemanticXaml.Colors
{
    public static class ColorServiceProviderExtensions
    {
        public static Color GetBackgroundColor(this IServiceProvider serviceProvider)
        {
            var color = new Color();

            var target = (IProvideValueTarget) serviceProvider.GetService(typeof (IProvideValueTarget));

            var frameworkElement = target.TargetObject as DependencyObject;

            if (frameworkElement != null)
            {
                GetBackgroundBrush(frameworkElement).IfIsOfType<SolidColorBrush>(b => color = b.Color);
            }

            return color;
        }

        static Brush GetBackgroundBrush(DependencyObject element)
        {            
            var brush = element.GetValue(Control.BackgroundProperty);

            if (brush != null)
                return brush as Brush;

            var parent = LogicalTreeHelper.GetParent(element);

            if (parent == null)
                return null;

            return GetBackgroundBrush(parent);
        }
    }
}