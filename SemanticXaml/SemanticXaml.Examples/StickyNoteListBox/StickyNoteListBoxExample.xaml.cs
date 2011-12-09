using System.Windows.Controls;

namespace SemanticXaml.Examples.StickyNoteListBox
{
    /// <summary>
    ///   Interaction logic for StickyNoteListBoxExample.xaml
    /// </summary>
    public partial class StickyNoteListBoxExample : UserControl
    {
        public StickyNoteListBoxExample()
        {
            InitializeComponent();

            var items = new[]
                            {
                                "Whatever",
                                "Whatever",
                                "Whatever",
                                "Whatever",
                                "Whatever",
                            };
            listBox.ItemsSource = items;
        }
    }
}