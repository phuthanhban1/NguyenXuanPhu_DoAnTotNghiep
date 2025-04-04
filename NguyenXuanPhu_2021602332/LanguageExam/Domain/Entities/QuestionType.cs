using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuestionType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // foreign key exam question type
        public Guid ExamQuestionTypeId { get; set; }
        public ExamQuestionType ExamQuestionType { get; set; }
        
        public List<DetailConstruction> DetailConstructions { get; set; }
    }
}
