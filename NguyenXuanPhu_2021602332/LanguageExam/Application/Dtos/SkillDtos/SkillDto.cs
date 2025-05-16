using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SkillDtos
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // created user
        public Guid CreatedUserId { get; set; }
        public string CreatedUserName { get; set; }
        // review user
        public Guid ReviewedUserId { get; set; }
        public string ReviewedUserName { get; set; }
        public DateOnly CreateDue { get; set; }
        public DateOnly ReviewDue { get; set; }
    }
   
}
