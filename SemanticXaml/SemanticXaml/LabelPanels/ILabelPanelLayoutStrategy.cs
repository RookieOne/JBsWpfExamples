using System.Windows;
using System.Windows.Controls;

namespace SemanticXaml.LabelPanels
{
    public interface ILabelPanelLayoutStrategy
    {
        void AddVisual(Label label, UIElement element, ILabelPanelGridFacade grid);
    }
}