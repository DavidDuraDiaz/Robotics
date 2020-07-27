using Robotics.Core.Entities;
using Robotics.Core.Interfaces;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Robotics.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Tries to validate the Users credentials
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password">Password</param>
        /// <returns>User found</returns>
        public async Task<Users> ValidateUser(string username, string password)
        {
            return await _context.Set<Users>().FirstOrDefaultAsync(user => user.Username.Equals(username) && user.Password == password);
        }
    }
}
