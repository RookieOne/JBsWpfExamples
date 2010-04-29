using System;

namespace TimeSheetDomain
{
    public class TimeTicket
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Owner { get; set; }
    }
}