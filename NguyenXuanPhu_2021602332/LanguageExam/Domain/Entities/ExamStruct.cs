using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExamStruct
    {
        public Guid Id { get; set; }
        public string Skill { get; set; }
        public int Order { get; set; }

        public Guid QuestionLevelId { get; set; }
        public QuestionType QuestionLevel { get; set; }

        public Exam Exam { get; set; }

    }
}
