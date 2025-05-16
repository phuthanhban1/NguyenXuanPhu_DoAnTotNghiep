using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamStructDetail
{
    public class ExamStructDetailDto
    {
        public Guid Id { get; set; }
        public string Skill { get; set; }
        public int Order { get; set; }
        public Guid QuestionTypeId { get; set; }
        public string QuestionTypeName { get; set; }
        public int Amount { get; set; }
       
    }
}
