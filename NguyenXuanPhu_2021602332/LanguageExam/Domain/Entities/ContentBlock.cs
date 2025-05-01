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
        public string? TextContent { get; set; }
        public bool IsConfirm { get; set; }
        public byte QuestionAmount { get; set; }
        public bool IsUsed { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly? UpdatedDate { get; set; }
        public string? UnConFirmedReason { get; set; }
        public byte Level { get; set; } // Độ khó từ 1-6
        public QuestionStruct QuestionStruct { get; set; }

        // foreign key audio file
        public Guid? AudioFileId { get; set; }
        public ExamFile? AudioFile { get; set; }

        // foreign key image file
        public Guid? ImageFileId { get; set; }
        public ExamFile? ImageFile { get; set; }

        // foreign key question level
        public Guid QuestionLevelId { get; set; }
        public QuestionType QuestionLevel { get; set; }

        public ExamQuestion? ExamQuestion { get; set; }
        public List<Question> Questions { get; set; }

        public List<SimilarQuestion> SimilarQuestions { get; set; }
    }
}
