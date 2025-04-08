using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Examinee
    {
        public Guid ExamId { get; set; }
        //public Exam Exam { get; set; }
        public Guid UserId { get; set; }
        //public User User { get; set; }
        public string? Location { get; set; }
        public int? Room { get; set; }
        public int? Score { get; set; }
        public List<DetailResult> DetailResults { get; set; }
    }
}
