using Microsoft.Extensions.Options;
using MongoDB.Helpers;
using MongoDB.Models.Entities;
using MongoDB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MongoDB.Repositories.Services
{

    public class ContactRepoService : MongoDbRepositoryBase<Contact>, IContactDataAccess, IDisposable
    {
        public ContactRepoService(IOptions<MongoDbSettings> options) : base(options)
        {

        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
