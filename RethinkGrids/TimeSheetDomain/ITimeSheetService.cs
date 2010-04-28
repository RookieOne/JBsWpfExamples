using System.Collections.Generic;

namespace TimeSheetDomain
{
    public interface ITimeSheetService
    {
        IEnumerable<Project> GetProjects();
    }
}