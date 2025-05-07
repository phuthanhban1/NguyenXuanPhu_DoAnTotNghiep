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
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }

        public Guid QuestionBankId { get; set; }
        public QuestionBank QuestionBank { get; set; }

        public List<ExamStructDetail> ExamStructDetails { get; set; }
        public List<ExamQuestion> ExamQuestions { get; set; }

    }
}
