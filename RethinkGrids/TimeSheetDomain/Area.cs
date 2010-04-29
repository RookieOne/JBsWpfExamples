using System.Collections.Generic;

namespace TimeSheetDomain
{
    public class Area
    {
        public Area()
        {
            TimeTickets = new List<TimeTicket>();
        }

        public string Name { get; set; }
        public List<TimeTicket> TimeTickets { get; set; }
    }
}