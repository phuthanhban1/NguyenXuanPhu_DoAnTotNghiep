using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamQuestionDetailDtos
{
    public class ExamQuestionDetailCreateDto
    {
        public Guid ExamId { get; set; }
        public Guid ExamStructId { get; set; }
    }
}
