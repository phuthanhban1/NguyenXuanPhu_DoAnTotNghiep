using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ExamContext context) : base(context)
        {
        }

        public async Task<Guid> GetIdByName(string name)
        {
            var roles = await FindAsync(r => r.Name == name);
            var role = roles.FirstOrDefault();
            return role == null ? Guid.Empty : role.Id;
        }

        public async Task<List<Role>> GetUserRole()
        {
            var roles = _context.Set<Role>().Where(r => r.Name != "quản trị viên").ToList();
            return roles;
        }
    }
}
