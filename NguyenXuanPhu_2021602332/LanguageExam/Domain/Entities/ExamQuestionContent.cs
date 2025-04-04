using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExamQuestionContent
    {
        public Guid Id { get; set; }
        public int QuestionNumber { get; set; }
        public Guid ContentBlockID { get; set; }
        public ContentBlock ContentBlock { get; set; }
        
    }
}
