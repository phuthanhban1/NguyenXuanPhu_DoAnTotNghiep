using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuestionLevel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        
        // foreign key: skill
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

        public List<ContentBlock> ContentBlocks { get; set; }
        public List<ExamStruct> ExamStructs { get; set; }
    }
}
