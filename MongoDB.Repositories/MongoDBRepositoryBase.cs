using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using BaseTypes;
using MongoDB.Helpers;
using MongoDB.Models;
using Microsoft.Extensions.Options;

namespace MongoDB.Repositories
{
    public abstract class MongoDbRepositoryBase<T> : IMongoRepository<T, string> where T : MongoDbEntity, new()
    {
        protected readonly IMongoCollection<T> Collection;
        private readonly MongoDbSettings settings;

        protected MongoDbRepositoryBase(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.Database);
            this.Collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? Collection.AsQueryable()
                : Collection.AsQueryable().Where(predicate);
        }

        public virtual Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }

        public virtual Task<T> GetByIdAsync(string id)
        {
            try
            {

                return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                var options = new InsertOneOptions { BypassDocumentValidation = false };
                await Collection.InsertOneAsync(entity, options);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            return (await Collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options)).IsAcknowledged;
        }

        public virtual async Task<T> UpdateAsync(string id, T entity)
        {
            try
            {
                return await Collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await Collection.FindOneAndReplaceAsync(predicate, entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public virtual async Task<T> DeleteAsync(string id)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public virtual async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            return await Collection.FindOneAndDeleteAsync(filter);
        }
    }
}
