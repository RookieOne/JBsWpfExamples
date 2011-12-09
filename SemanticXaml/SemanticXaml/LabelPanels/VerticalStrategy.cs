using System.Windows;
using System.Windows.Controls;

namespace SemanticXaml.LabelPanels
{
    public class VerticalStrategy : ILabelPanelLayoutStrategy
    {
        public void AddVisual(Label label, UIElement element, ILabelPanelGridFacade grid)
        {
            int lastCol = grid.GetLastColumn();

            if (lastCol < 1)
                grid.AddColumnPair();

            grid.AddRow();

            int row = grid.GetLastRow();

            grid.AddVisualToGrid(row, 0, label);
            grid.AddVisualToGrid(row, 1, element);
        }
    }
}