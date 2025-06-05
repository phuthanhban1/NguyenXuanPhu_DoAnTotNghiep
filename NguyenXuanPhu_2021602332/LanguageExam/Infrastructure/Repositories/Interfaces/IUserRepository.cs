using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Login(string email, string password);
        Task<List<User>> GetAccounts(Guid id);
        Task<List<User>> GetUsersByRole(int role);
        Task<User> GetUserByEmail(string email, Guid roleId);
        Task<User> GetUserById(Guid id);
        Task<User> GetByEmail(string email);
    }
}
