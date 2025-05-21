using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AnswerDtos
{
    public class AnswerDto : AnswerCreateDto
    {
        public Guid? Id { get; set; }
    }
}
