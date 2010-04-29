using System.Collections.Generic;

namespace TimeSheetDomain
{
    public class MockService : ITimeSheetService
    {
        public MockService()
        {
            _projects = new List<Project>
                            {
                                new Project {Name = "Frank"},                                
                                new Project {Name = "Expense Evolution"},
                                new Project {Name = "Semantic Xaml"},
                                new Project {Name = "M-V-VM"},
                            };
            _projects.Add(CodeTimeCQRS());
            _projects.Add(ChimeraProject());
        }

        readonly List<Project> _projects;

        public IEnumerable<Project> GetProjects()
        {
            return _projects;
        }

        static Project CodeTimeCQRS()
        {
            var project = new Project { Name = "CodeTime CQRS" };

            project.Areas.Add(new Area { Name = "Event Broker" });
            project.Areas.Add(new Area { Name = "Event Storage" });
            project.Areas.Add(new Area { Name = "Aggregates" });
            project.Areas.Add(new Area { Name = "Unit of Work" });
            project.Areas.Add(new Area { Name = "Read" });
            project.Areas.Add(new Area { Name = "Sample App" });

            return project;
        }

        static Project ChimeraProject()
        {
            var project = new Project { Name = "Chimera" };

            project.Areas.Add(new Area { Name = "Processing Engine" });
            project.Areas.Add(new Area { Name = "Routing" });
            project.Areas.Add(new Area { Name = "ViewModel Engine" });
            project.Areas.Add(new Area { Name = "View Engine" });
            project.Areas.Add(new Area { Name = "Controllers" });
            project.Areas.Add(new Area { Name = "Sample App" });

            return project;
        }
    }
}