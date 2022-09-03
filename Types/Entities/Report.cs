using BaseTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Types.Enums;

namespace Types.Entities
{
    public class Report : UpdatableDBEntity
    {
        public Guid UUId { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
