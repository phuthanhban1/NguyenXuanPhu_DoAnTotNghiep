using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SkillDtos
{
    public class SkillDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BankName { get; set; }
        public string Language { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateTime QuestionCreateDue { get; set; }
        public DateTime QuestionReviewDue { get; set; }
        public bool IsConfirm { get; set; }
    }
}
