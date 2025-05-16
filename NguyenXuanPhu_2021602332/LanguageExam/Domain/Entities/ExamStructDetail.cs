using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExamStructDetail
    {
        public Guid Id { get; set; }
        public string Skill { get; set; }
        public int Order { get; set; }
        public Guid QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }
        public int Amount { get; set; }

        public Guid ExamStructId { get; set; }
        public ExamStruct ExamStruct { get; set; }
        
    }
}
