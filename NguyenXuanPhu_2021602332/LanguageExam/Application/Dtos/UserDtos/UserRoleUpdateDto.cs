using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
    public class UserRoleUpdateDto
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
    }
}
