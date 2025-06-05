using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamDtos
{
    public class ExamCreateDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime RegistDate { get; set; }
        public int Amount { get; set; }
        public string Password { get; set; }
        public int Fee { get; set; }
        public DateTime CreateQuestionDue { get; set; }
        // id created exam question
        public string Email { get; set; }

    }
}
