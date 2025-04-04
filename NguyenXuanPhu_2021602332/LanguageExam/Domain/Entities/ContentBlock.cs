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
        public string Content { get; set; }
        public bool IsConfirm { get; set; }
        public string? UnConFirmedReason { get; set; }
        public Guid CreatedUserId { get; set; }
        public User CreatedUser { get; set; }
        public Guid ConfirmedUserId { get; set; }
        public User ConfirmedUser { get; set; }

        // foreign key audio file
        public Guid AudioFileId { get; set; }
        public AudioFile? AudioFile { get; set; }

        // foreign key question type
        public Guid QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        public ExamQuestion ExamQuestion { get; set; }
        public List<Question> Questions { get; set; }
    }
}
