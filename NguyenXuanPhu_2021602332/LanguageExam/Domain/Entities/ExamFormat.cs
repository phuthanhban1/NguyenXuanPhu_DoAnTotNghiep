using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExamFormat
    {
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public Guid ExamQuestionTypeId { get; set; }
        public ExamQuestionType ExamQuestionType { get; set; }
        // foreign key: Audio file
        public Guid? AudioFileId { get; set; }
        public AudioFile? AudioFile { get; set; }

    }
}
