using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SkillDtos
{
    public class SkillUpdateDto
    {
        public Guid Id { get; set; }
        // created user
        public Guid? CreatedUserId { get; set; }
        // review user
        public Guid? ReviewedUserId { get; set; }
        public DateTime? CreatedDue { get; set; }
        public DateTime? ReviewedDue { get; set; }
    }
}
