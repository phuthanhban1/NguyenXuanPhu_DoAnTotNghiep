using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamQuestionDtos
{
    public class ExamQuestionCreateDto
    {
        public Guid ExamId { get; set; }

        // foreign key exam struct
        public Guid ExamStructId { get; set; }
    }
}
