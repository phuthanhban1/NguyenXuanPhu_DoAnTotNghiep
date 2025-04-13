using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AnswerDtos
{
    public class AnswerCreateDto
    {
        public string Content { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
