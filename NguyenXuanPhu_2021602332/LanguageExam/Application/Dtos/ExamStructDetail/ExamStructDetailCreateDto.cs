using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamStructDetail
{
    public class ExamStructDetailCreateDto
    {
        public string Skill { get; set; }
        public int Order { get; set; }
        public Guid QuestionTypeId { get; set; }
        public int Amount { get; set; }
        public Guid ExamStructId { get; set; }
    }
}
