using System.Collections.Generic;
using System.Windows;
using TimeSheetDomain;

namespace RethinkGrids
{
    /// <summary>
    /// Interaction logic for WithoutGrids.xaml
    /// </summary>
    public partial class WithoutGrids : Window
    {
        public WithoutGrids()
        {
            InitializeComponent();

            var service = new MockService();

            Projects = service.GetProjects();

            DataContext = this;
        }

        public IEnumerable<Project> Projects { get; set; }
    }
}