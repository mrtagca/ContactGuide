using Microsoft.Extensions.Options;
using MongoDB.Helpers;
using MongoDB.Models.Entities;
using MongoDB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Repositories.Services
{
    public class ReportRepoService : MongoDbRepositoryBase<Report>, IReportDataAccess, IDisposable
    {
        public ReportRepoService(IOptions<MongoDbSettings> options) : base(options)
        {

        }
        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
