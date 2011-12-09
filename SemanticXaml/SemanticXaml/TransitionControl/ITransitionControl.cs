using System.Windows;
using System.Windows.Controls;

namespace SemanticXaml.TransitionControl
{
    public interface ITransitionControl
    {
        void Add(FrameworkElement newContent);
        void Remove(FrameworkElement oldContent);
        bool Contains(FrameworkElement element);
        Control AsControl();
    }
}