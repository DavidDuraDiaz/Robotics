using Robotics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Robotics.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Find(int Id);
        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetFiltered(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
