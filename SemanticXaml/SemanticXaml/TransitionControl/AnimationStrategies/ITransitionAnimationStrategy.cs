using System.Windows;

namespace SemanticXaml.TransitionControl.AnimationStrategies
{
    public interface ITransitionAnimationStrategy
    {
        void Transition(ITransitionControl container,
                        FrameworkElement oldContent,
                        FrameworkElement newContent);
    }
}