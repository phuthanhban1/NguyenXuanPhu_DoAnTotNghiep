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
        public DateOnly CreatedDate { get; set; }
        public DateOnly RegistDate { get; set; }
        public DateOnly StartDate { get; set; }
        public string Password { get; set; }
        public int Amount { get; set; }
        public int Fee { get; set; }
        // id manager
        public Guid ManagerId { get; set; }
        public User Manager { get; set; }
        public DateOnly CreateQuestionDue { get; set; }
        public bool IsCreated { get; set; }
        // id created exam question
        public Guid CreatedQuestionUserId { get; set; }
        public User CreatedQuestionUser { get; set; }

        public List<Examinee> Examinees { get; set; }
        public ExamQuestion ExamQuestion { get; set; }



    }
}
