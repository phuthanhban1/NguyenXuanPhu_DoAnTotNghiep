using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExamQuestionType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte NumberQuestion { get; set; }
        public float Duration { get; set; }
        public List<ExamFormat> ExamFormats { get; set; }
        public List<QuestionType> QuestionTypes { get; set; }
        
    }
}
