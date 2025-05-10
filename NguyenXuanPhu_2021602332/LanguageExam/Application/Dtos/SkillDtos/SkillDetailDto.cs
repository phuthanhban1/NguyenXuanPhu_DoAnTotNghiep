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
        public Guid? CreateUserId { get; set; }
        public string? CreateUserName { get; set; }
        public Guid? ReviewUserId { get; set; }
        public string? ReviewUserName { get; set; }
        public DateTime? CreateDue { get; set; }
        public DateTime? ReviewDue { get; set; }
        public bool IsCreateConfirm { get; set; }
        public bool IsReviewConfirm { get; set; }
    }
}
