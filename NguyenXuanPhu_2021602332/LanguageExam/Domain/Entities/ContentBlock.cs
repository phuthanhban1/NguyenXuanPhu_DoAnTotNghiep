using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContentBlock
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public byte Status { get; set; }
        public byte Level { get; set; }
        public bool IsUsed { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly? UpdatedDate { get; set; }
        public string? RejectionReason { get; set; }

        // foreign key audio file
        public Guid? AudioFileId { get; set; }
        public ExamFile? AudioFile { get; set; }

        // foreign key image file
        public Guid? ImageFileId { get; set; }
        public ExamFile? ImageFile { get; set; }

        // foreign key question level
        public Guid QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        public ExamQuestion? ExamQuestion { get; set; }
        public List<Question> Questions { get; set; }

        public List<SimilarQuestion> SimilarQuestions1 { get; set; }
        public List<SimilarQuestion> SimilarQuestions2 { get; set; }
    }
}
