using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.DetailResultDtos
{
    public class DetailResultCreateDto
    {
        public int QuestionNumber { get; set; }
        // fK: answer
        public Guid AnswerId { get; set; } 

        // foreign key examinee
        public Guid ExamId { get; set; }
        public Guid UserId { get; set; }
    }
}
