using Robotics.Core.Entities;
using Robotics.Core.Interfaces;
using System.Data.Entity;

namespace Robotics.Persistence.Repository
{
    public class BookRepository : Repository<Books>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context)
        {
        }
    }
}
