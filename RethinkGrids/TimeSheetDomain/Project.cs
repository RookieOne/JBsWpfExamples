using System.Collections.Generic;

namespace TimeSheetDomain
{
    public class Project
    {
        public Project()
        {
            Areas = new List<Area>();
        }

        public string Name { get; set; }
        public List<Area> Areas { get; set; }
    }
}