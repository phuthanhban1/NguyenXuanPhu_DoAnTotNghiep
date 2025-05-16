using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SkillDtos
{
    public class SkillOverViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsConfirm { get; set; }
        public string Task { get; set; }
        public string QuestionBankName { get; set; }
        public string Language { get; set; }
        public DateOnly DueDate { get; set; }
    }
}
