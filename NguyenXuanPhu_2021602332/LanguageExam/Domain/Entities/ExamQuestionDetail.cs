using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExamQuestionDetail
    {
        public Guid Id { get; set; }
        public string Skill { get; set; }
        public int Order { get; set; }
        public Guid ContentBlockId { get; set; }
        public ContentBlock ContentBlock { get; set; }
        public Guid ExamQuestionId { get; set; }
        public ExamQuestion ExamQuestion { get; set; }
    }
}
