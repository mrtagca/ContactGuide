using BaseTypes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Models.Entities
{
    public class LocationReport : MongoDbEntity, ILocationReport
    {
        public List<LocationReportItem> ReportItems { get; set; }
    }
}
