using BaseTypes.Entities;
using BaseTypes.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Models.Entities
{
    public class Report : MongoDbEntity, IReport
    {
        public Guid UUId { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
