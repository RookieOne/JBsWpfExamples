using System.Windows;

namespace SemanticXaml.LabelPanels
{
    public interface ILabelPanelGridFacade
    {
        void AddColumnPair();
        void AddRow();
        int GetLastRow();
        void AddVisualToGrid(int row, int col, UIElement visual);
        int GetLastColumn();
    }
}