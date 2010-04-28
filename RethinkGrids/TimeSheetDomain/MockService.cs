using System.Collections.Generic;

namespace TimeSheetDomain
{
    public class MockService : ITimeSheetService
    {
        public MockService()
        {
            _projects = new List<Project>
                            {
                                new Project {Name = "Timesheet"},
                                new Project {Name = "Frank"},
                                new Project {Name = "Chimera"},
                                new Project {Name = "CodeTime CQRS"},
                                new Project {Name = "Expense Evolution"},
                                new Project {Name = "Semantic Xaml"},
                                new Project {Name = "M-V-VM"},
                            };
        }

        readonly List<Project> _projects;

        public IEnumerable<Project> GetProjects()
        {
            return _projects;
        }
    }
}