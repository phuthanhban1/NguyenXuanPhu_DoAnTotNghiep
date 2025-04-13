using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.QuestionLevelDtos
{
    public class QuestionLevelCreateDto
    {
        
        public string Name { get; set; }
        public int Level { get; set; }

        // foreign key: skill
        public Guid SkillId { get; set; }
    }
}
