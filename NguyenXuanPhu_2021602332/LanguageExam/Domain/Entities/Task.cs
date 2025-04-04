using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        // foreign key exam
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        // foreign key user
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
