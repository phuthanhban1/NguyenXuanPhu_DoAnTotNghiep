using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExamQuestion
    {
        public Guid Id { get; set; }
        //foreign key exam
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }

        // foreign key exam struct
        public Guid ExamStructId { get; set; }
        public ExamStruct ExamStruct { get; set; }

        public List<ExamQuestionDetail>? ExamQuestionDetails { get; set; }


    }
}
