using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.QuestionTypeDtos
{
    public class QuestionTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsSingle { get; set; }
        public bool HasImage { get; set; }
        // foreign key: skill
        public string? SkillName { get; set; }
    }
}
