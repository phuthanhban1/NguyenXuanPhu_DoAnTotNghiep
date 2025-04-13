using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.DetailResultDtos
{
    public class DetailResultUpdateDto
    {
        public Guid Id { get; set; }
        public int QuestionNumber { get; set; }
        // fK: answer
        public Guid AnswerId { get; set; }

    }
}
