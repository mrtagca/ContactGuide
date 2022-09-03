using BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repositories
{
    public interface IDBRepository<TEntity> where TEntity : DBEntityBase
    {
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        TEntity GetQueryById(Guid id);
    }
}
