using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamineeDtos
{
    public class ExamineeScoreDto
    {
        public Guid ExamId { get; set; }
        public string ExamineeNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
