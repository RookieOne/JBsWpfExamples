using System.Windows;
using System.Windows.Media;
using SemanticXaml.Extensions;
using SemanticXaml.FluentWpf;

namespace SemanticXaml.AnimatedPanel.AnimationStrategies
{
    public class SlideUpAnimationStrategy : IItemAnimationStrategy
    {
        public SlideUpAnimationStrategy()
        {
            Reset();
        }

        const double Amount_To_Increase_Delay = 100;
        double _delay;

        public void Reset()
        {
            _delay = 100;
        }

        public void AnimateItem(FrameworkElement item)
        {
            var translate = new TranslateTransform(0, 300);

            item.RenderTransform = translate;
            item.Opacity = 0;

            Animate.The(TranslateTransform.YProperty)
                .From(300)
                .To(0)
                .Delay(_delay)
                .For(300.MilliSeconds())
                .Create()
                .AnimateOn(translate);

            Animate.The(UIElement.OpacityProperty)
                .From(0)
                .To(100)
                .Delay(_delay)
                .For(300.MilliSeconds())
                .Create()
                .AnimateOn(item);

            _delay += Amount_To_Increase_Delay;
        }
    }
}