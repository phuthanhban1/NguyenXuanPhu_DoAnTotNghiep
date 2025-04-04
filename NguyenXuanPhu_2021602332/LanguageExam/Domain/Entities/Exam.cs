using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime BeginDate { get; set; }
        public string Password { get; set; }
        public int Fee { get; set; }
        // foreign key
        public Guid CreatedUserId { get; set; }
        public User CreatedUser { get; set; }
        // 1-1 relation
        public ExamQuestion ExamQuestion { get; set; }
        public List<Task> Tasks { get; set; }
        public List<ExamQuestionContent> ExamContents { get; set; }

    }
}
