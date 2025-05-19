using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamDtos
{
    public class ExamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly RegistDate { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly CreateQuestionDue { get; set; }
        public int Fee { get; set; }
        public string Password { get; set; }
        public int Amount { get; set; }
    }
}
