using Robotics.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Robotics.Core.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<Users> ValidateUser(string username, string password);
    }
}
