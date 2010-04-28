using System.Collections.Generic;
using System.Windows;
using TimeSheetDomain;

namespace RethinkGrids
{
    /// <summary>
    /// Interaction logic for WithGrids.xaml
    /// </summary>
    public partial class WithGrids : Window
    {
        public WithGrids()
        {
            InitializeComponent();

            var service = new MockService();

            Projects = service.GetProjects();

            DataContext = this;
        }

        public IEnumerable<Project> Projects { get; set; }
    }
}