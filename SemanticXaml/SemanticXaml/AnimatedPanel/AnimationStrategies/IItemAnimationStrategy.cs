using System.Windows;

namespace SemanticXaml.AnimatedPanel.AnimationStrategies
{
    public interface IItemAnimationStrategy
    {
        void Reset();
        void AnimateItem(FrameworkElement item);
    }
}