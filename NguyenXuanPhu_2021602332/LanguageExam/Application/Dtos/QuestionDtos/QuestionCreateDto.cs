using Application.Dtos.AnswerDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.QuestionDtos
{
    public class QuestionCreateDto
    {
        public string? Content { get; set; }
        public byte Score { get; set; }
        public List<AnswerCreateDto> Answers { get; set; }
    }
}
