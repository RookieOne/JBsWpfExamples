using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfLibrary
{
    public class AnimatedStackPanel : StackPanel
    {
        public static readonly DependencyProperty HasBeenAnimatedProperty =
            DependencyProperty.RegisterAttached("HasBeenAnimated",
                                                typeof(bool),
                                                typeof(AnimatedStackPanel));

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (FrameworkElement child in Children)
            {
                child.Measure(availableSize);
            }

            return base.MeasureOverride(availableSize);
        }

        public static bool GetHasBeenAnimated(DependencyObject o)
        {
            return (bool)o.GetValue(HasBeenAnimatedProperty);
        }

        public static void SetHasBeenAnimated(DependencyObject o, bool value)
        {
            o.SetValue(HasBeenAnimatedProperty, value);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double previousHeight = 0;

            double delay = 100;
            Action increaseDelay = () => delay += 100;

            foreach (FrameworkElement child in Children)
            {
                if (GetHasBeenAnimated(child))
                    continue;

                child.Arrange(new Rect(0, previousHeight, child.DesiredSize.Width, child.DesiredSize.Height));
                previousHeight += child.DesiredSize.Height;

                var translate = new TranslateTransform(100, 0);

                child.RenderTransform = translate;

                var animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(300));
                animation.BeginTime = TimeSpan.FromMilliseconds(delay);

                translate.BeginAnimation(TranslateTransform.XProperty, animation);

                SetHasBeenAnimated(child, true);

                increaseDelay();
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}