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
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime BeginDate { get; set; }
        public int Fee { get; set; }
        public bool IsActive { get; set; }
    }
}
