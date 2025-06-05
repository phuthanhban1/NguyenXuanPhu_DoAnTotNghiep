using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.QuestionBankDtos
{
    public class QuestionBankUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
    }
}
