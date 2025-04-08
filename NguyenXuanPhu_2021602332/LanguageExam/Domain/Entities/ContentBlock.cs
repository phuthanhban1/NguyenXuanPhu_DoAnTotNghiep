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
        public bool IsConfirm { get; set; }
        public DateTime? UsedDate { get; set; }
        public bool IsUsed { get; set; }
        public string? UnConFirmedReason { get; set; }

        // foreign key audio file
        public Guid? AudioFileId { get; set; }
        public AudioFile? AudioFile { get; set; }

        // foreign key question level
        public Guid QuestionLevelId { get; set; }
        public QuestionLevel QuestionLevel { get; set; }

        public ExamQuestion? ExamQuestion { get; set; }
        public List<Question> Questions { get; set; }
    }
}
