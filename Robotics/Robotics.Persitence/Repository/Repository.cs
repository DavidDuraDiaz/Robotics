using Robotics.Core.Entities;
using Robotics.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Robotics.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Tries to find a Book by Id
        /// </summary>
        /// <param name="Id">Id of the desired Book</param>
        /// <returns>Book found</returns>
        public async Task<TEntity> Find(int Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        /// <summary>
        /// Retrieves all the Books from the Database
        /// </summary>
        /// <returns>List Containing all the Books</returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Retrieves the Books from the Database that mach the received filter
        /// </summary>
        /// <param name="predicate">The discriminator to filter the Books</param>
        /// <returns>List containing the matching Books</returns>
        public async Task<IEnumerable<TEntity>> GetFiltered(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Retrieves the first book that matches the filter.
        /// </summary>
        /// <param name="predicate">The discriminator to filter the Books</param>
        /// <returns>The Book selected</returns>
        public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

    }
}
