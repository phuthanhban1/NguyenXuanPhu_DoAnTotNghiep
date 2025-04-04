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
        public int QuestionNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        //foreign key exam
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }

        // foreign key content block
        public Guid ContentBlockId { get; set; }
        public ContentBlock ContentBlock { get; set; }

        // foreign key user
        public Guid CreatedUserId { get; set; }
        public User CreatedUser { get; set; }

        public List<DetailConstruction> DetailConstructions { get; set; }

    }
}
