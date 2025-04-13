using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamineeDtos
{
    public class ExamineeUpdateDto
    {
        public Guid ExamId { get; set; }
        //public Exam Exam { get; set; }
        public Guid UserId { get; set; }
        //public User User { get; set; }
        public string? Location { get; set; }
        public int? Room { get; set; }
    }
}
