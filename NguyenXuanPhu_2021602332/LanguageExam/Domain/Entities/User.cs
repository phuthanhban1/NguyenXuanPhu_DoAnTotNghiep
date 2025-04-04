using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Exam>? Exams { get; set; }
        public ExamQuestion? ExamQuestions { get; set; }

        //
        public List<Task> Tasks { get; set; }

        // foreign key role 
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
