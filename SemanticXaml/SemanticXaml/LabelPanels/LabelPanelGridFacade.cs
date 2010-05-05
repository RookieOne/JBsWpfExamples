using System.Windows;
using System.Windows.Controls;

namespace SemanticXaml.LabelPanels
{
    public class LabelPanelGridFacade : ILabelPanelGridFacade
    {
        public LabelPanelGridFacade(Grid grid)
        {
            _Grid = grid;
        }

        readonly Grid _Grid;

        public void AddColumnPair()
        {
            var labelColumn = new ColumnDefinition();
            labelColumn.Width = GridLength.Auto;
            _Grid.ColumnDefinitions.Add(labelColumn);

            var contentColumn = new ColumnDefinition();
            contentColumn.Width = new GridLength(1, GridUnitType.Star);
            _Grid.ColumnDefinitions.Add(contentColumn);
        }

        public void AddRow()
        {
            var rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;

            _Grid.RowDefinitions.Add(rowDefinition);
        }

        public int GetLastRow()
        {
            return _Grid.RowDefinitions.Count - 1;
        }

        public void AddVisualToGrid(int row, int col, UIElement visual)
        {
            Grid.SetRow(visual, row);
            Grid.SetColumn(visual, col);

            _Grid.Children.Add(visual);
        }

        public int GetLastColumn()
        {
            return _Grid.ColumnDefinitions.Count - 1;
        }
    }
}