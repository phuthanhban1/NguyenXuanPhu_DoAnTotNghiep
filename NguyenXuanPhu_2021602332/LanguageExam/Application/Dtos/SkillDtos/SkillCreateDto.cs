using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SkillDtos
{
    public class SkillCreateDto
    {
        public string Name { get; set; }
        // created user
        public Guid CreatedUserId { get; set; }
        // review user
        public Guid ReviewedUserId { get; set; }
        public DateTime CreateDue { get; set; }
        public DateTime ReviewDue { get; set; }
        // foreign key question bank
        public Guid QuestionBankId { get; set; }

    }
}
