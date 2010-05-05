using System;
using System.Windows.Controls;

namespace SemanticXaml.Examples.Controls
{
    /// <summary>
    ///   Interaction logic for DisplayDate.xaml
    /// </summary>
    public partial class DisplayDateExample : UserControl
    {
        public DisplayDateExample()
        {
            InitializeComponent();

            date.Date = new DateTime(2010, 5, 5);
        }
    }
}