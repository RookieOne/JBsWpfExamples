using System.Windows;
using System.Windows.Media;
using SemanticXaml.Extensions;
using SemanticXaml.FluentWpf;

namespace SemanticXaml.AnimatedPanel.AnimationStrategies
{
    public class SlideAnimationStrategy : IItemAnimationStrategy
    {
        public SlideAnimationStrategy()
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
            var translate = new TranslateTransform(100, 0);
            item.RenderTransform = translate;

            Animate.The(TranslateTransform.XProperty)
                .From(100)
                .To(0)
                .Delay(_delay)
                .For(300.MilliSeconds())
                .Create()
                .AnimateOn(translate);                

            //

            //var animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(300));
            //animation.BeginTime = TimeSpan.FromMilliseconds(_delay);

            //translate.BeginAnimation(TranslateTransform.XProperty, animation);

            _delay += Amount_To_Increase_Delay;
        }
    }
}