using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetailConstruction
    {
        public Guid Id { get; set; }
        public int QuestionNumber { get; set; }
        // foreign key exam question
        public Guid ExamQuestionId { get; set; }
        public ExamQuestion ExamQuestion { get; set; }

        // foreign key question type
        public Guid QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

    }
}
