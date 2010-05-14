using System.Windows;
using System.Windows.Media;
using SemanticXaml.Extensions;
using SemanticXaml.FluentWpf;

namespace SemanticXaml.AnimatedPanel.AnimationStrategies
{
    public class SlideDownAnimationStrategy : IItemAnimationStrategy
    {
        public SlideDownAnimationStrategy()
        {
            Reset();
        }

        const double Amount_To_Increase_Delay = 200;
        double _delay;

        public void Reset()
        {
            _delay = 100;
        }

        public void AnimateItem(FrameworkElement item)
        {
            var translate = new TranslateTransform(0, -50);

            //Panel.SetZIndex(item, -1);
            item.RenderTransform = translate;
            item.Opacity = 0;

            Animate.The(TranslateTransform.YProperty)
                .From(-50)
                .To(0)
                .Delay(_delay)
                .For(800.MilliSeconds())
                .Create()
                .AnimateOn(translate);

            Animate.The(UIElement.OpacityProperty)
                .From(0)
                .To(100)
                .Delay(_delay)
                .For(800.MilliSeconds())
                .Create()
                .AnimateOn(item);

            //Animate.The(Panel.ZIndexProperty)
            //    .From(-100)
            //    .To(0)
            //    .Delay(_delay)
            //    .For(300.MilliSeconds())
            //    .Create()
            //    .AnimateOn(item);

            _delay += Amount_To_Increase_Delay;
        }
    }
}