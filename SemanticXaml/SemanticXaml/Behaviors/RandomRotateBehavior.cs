using System;
using System.Windows;
using System.Windows.Media;

namespace SemanticXaml.Behaviors
{
    public static class RandomRotateBehavior
    {
        static RandomRotateBehavior()
        {
            MaxRotateProperty = DependencyProperty.RegisterAttached("MaxRotate", typeof (double),
                                                                    typeof (object),
                                                                    new PropertyMetadata(0d, OnRotateChanged));

            MinRotateProperty = DependencyProperty.RegisterAttached("MinRotate", typeof (double),
                                                                    typeof (object),
                                                                    new PropertyMetadata(0d, OnRotateChanged));
        }

        public static DependencyProperty MaxRotateProperty;
        public static DependencyProperty MinRotateProperty;
        static readonly Random _Random = new Random();

        public static void SetMaxRotate(DependencyObject o, double value)
        {
            o.SetValue(MaxRotateProperty, value);
        }

        public static double GetMaxRotate(DependencyObject o)
        {
            return (double) o.GetValue(MaxRotateProperty);
        }

        public static void SetMinRotate(DependencyObject o, double value)
        {
            o.SetValue(MinRotateProperty, value);
        }

        public static double GetMinRotate(DependencyObject o)
        {
            return (double) o.GetValue(MinRotateProperty);
        }

        static void OnRotateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = d as FrameworkElement;

            if (frameworkElement == null)
                return;

            double value = _Random.NextDouble();

            double min = GetMinRotate(d);
            double max = GetMaxRotate(d);

            double range = max - min;
            double addToMin = range*value;

            double angle = min + addToMin;

            frameworkElement.LayoutTransform = new RotateTransform(angle);
        }
    }
}