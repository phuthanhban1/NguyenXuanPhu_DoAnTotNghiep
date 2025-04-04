using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetailResult
    {
        public Guid Id { get; set; }
        public int QuestionNumber { get; set; }
        public byte Answer { get; set; }
        // foreign key examinee
        public Guid ExamId { get; set; }
        public Guid UserId { get; set; }
        public Examinee Examinee { get; set; }
    }
}
