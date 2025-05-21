using Application.Dtos.AnswerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.QuestionDtos
{
    public class QuestionCreateDto2
    {
        public string? Content { get; set; }
        public byte Score { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
