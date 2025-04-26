using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
    public class GetAllUserDto
    {
        public Guid Id { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
