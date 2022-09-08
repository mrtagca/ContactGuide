using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Entities
{
    public interface ILocationReport
    {
        public List<LocationReportItem> ReportItems { get; set; }
    }

    public class LocationReportItem
    {
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneCount { get; set; }
    }
}
