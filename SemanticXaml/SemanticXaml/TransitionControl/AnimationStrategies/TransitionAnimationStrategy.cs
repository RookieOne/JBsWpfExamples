using System.Windows;
using SemanticXaml.FluentWpf;

namespace SemanticXaml.TransitionControl.AnimationStrategies
{
    public abstract class TransitionAnimationStrategy : ITransitionAnimationStrategy
    {
        public void Transition(ITransitionControl container, FrameworkElement oldContent, FrameworkElement newContent)
        {
            FrameworkElement newContentToAdd = ModifyNewContent(container, newContent);

            container.Add(newContentToAdd);

            if (oldContent != null)
            {
                GetOutAnimation()
                    .UponCompletion(() => container.Remove(oldContent))
                    .AnimateOn(oldContent);
            }

            if (newContentToAdd != null)
            {
                GetInAnimation()
                    .AnimateOn(newContentToAdd);
            }
        }

        protected virtual FrameworkElement ModifyNewContent(ITransitionControl container, FrameworkElement newContent)
        {
            return newContent;
        }

        protected virtual Animation GetOutAnimation()
        {
            return null;
        }

        protected virtual Animation GetInAnimation()
        {
            return null;
        }
    }
}