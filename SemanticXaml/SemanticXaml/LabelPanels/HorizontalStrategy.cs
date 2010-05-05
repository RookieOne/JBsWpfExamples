using System.Windows;
using System.Windows.Controls;

namespace SemanticXaml.LabelPanels
{
    public class HorizontalStrategy : ILabelPanelLayoutStrategy
    {        
        public void AddVisual(Label label, UIElement element, ILabelPanelGridFacade grid)
        {
            int lastRow = grid.GetLastRow();

            if (lastRow < 0)
            {
                grid.AddRow();
                lastRow = grid.GetLastRow();
            }

            grid.AddColumnPair();

            int col = grid.GetLastColumn();

            grid.AddVisualToGrid(lastRow, col - 1, label);
            grid.AddVisualToGrid(lastRow, col, element);
        }
    }
}