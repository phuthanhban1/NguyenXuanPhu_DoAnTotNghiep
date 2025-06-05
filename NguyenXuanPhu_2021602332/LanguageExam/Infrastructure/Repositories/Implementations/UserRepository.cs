using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ExamContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmail(string email, Guid roleId)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == email && u.RoleId == roleId);
            return user;
        }
        public async Task<List<User>> GetAccounts(Guid id)
        {
            var list = await _context.User.Include(r => r.Role)
                .Where(x => x.RoleId != Guid.Parse("2959CA56-A667-46A0-ACEA-EBA1E9961419")).ToListAsync();
            return list;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _context.User.Include(r => r.Role)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return user;
        }
        public async Task<List<User>> GetUsersByRole(int role)
        {
            List<User> list = new List<User>();
            string roleName = "";
            if(role == 1) { roleName = "người tạo câu hỏi"; }
            else if(role == 2) { roleName = "người đánh giá câu hỏi"; }
            else if(role == 3) { roleName = "người tạo đề"; }
                list = await _context.User
                        .Include(u => u.Role)
                        .Include(u => u.Ward)
                        .Include(u => u.ImageFace)
                        .Include(u => u.ImageIdCardBefore)
                        .Include(u => u.ImageIdCardAfter)
                    .Where(x => x.Role.Name == roleName).ToListAsync();
            return list;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = _context.User
                        .Include(u => u.Role)
                        .Include(u => u.Ward)
                        .Include(u => u.ImageFace)
                        .Include(u => u.ImageIdCardBefore)
                        .Include(u => u.ImageIdCardAfter)
                    .FirstOrDefault(x => x.Id == id);
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = _context.User.FirstOrDefault(x => x.Email == email);
            return user;
        }
    }
}
