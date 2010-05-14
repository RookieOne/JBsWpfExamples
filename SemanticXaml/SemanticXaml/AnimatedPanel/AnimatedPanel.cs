using System.Windows;
using System.Windows.Controls;
using SemanticXaml.AnimatedPanel.AnimationStrategies;

namespace SemanticXaml.AnimatedPanel
{
    public class AnimatedPanel : StackPanel
    {
        static AnimatedPanel()
        {
            AnimationStrategyProperty = DependencyProperty.Register("AnimationStrategy",
                                                                    typeof (IItemAnimationStrategy),
                                                                    typeof (AnimatedPanel),
                                                                    new PropertyMetadata(new SlideAnimationStrategy()));

            HasBeenAnimatedProperty =
                DependencyProperty.RegisterAttached("HasBeenAnimated",
                                                    typeof (bool),
                                                    typeof (AnimatedPanel));
        }

        public static readonly DependencyProperty AnimationStrategyProperty;

        public static readonly DependencyProperty HasBeenAnimatedProperty;

        public IItemAnimationStrategy AnimationStrategy
        {
            get { return (IItemAnimationStrategy) GetValue(AnimationStrategyProperty); }
            set { SetValue(AnimationStrategyProperty, value); }
        }

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
            return (bool) o.GetValue(HasBeenAnimatedProperty);
        }

        public static void SetHasBeenAnimated(DependencyObject o, bool value)
        {
            o.SetValue(HasBeenAnimatedProperty, value);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double previousHeight = 0;

            AnimationStrategy.Reset();
            
            foreach (FrameworkElement child in Children)
            {
                child.Arrange(new Rect(0, previousHeight, child.DesiredSize.Width, child.DesiredSize.Height));

                previousHeight += child.DesiredSize.Height;

                if (GetHasBeenAnimated(child))
                    continue;                               

                AnimationStrategy.AnimateItem(child);

                SetHasBeenAnimated(child, true);
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}