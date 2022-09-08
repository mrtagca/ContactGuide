using MongoDB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Repositories.Interfaces
{
    public interface IReportDataAccess : IMongoRepository<Report, string>
    {

    }
}
