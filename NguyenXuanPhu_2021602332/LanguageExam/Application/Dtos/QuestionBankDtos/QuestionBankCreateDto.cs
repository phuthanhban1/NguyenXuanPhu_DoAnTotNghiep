using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.QuestionBankDtos
{
    public class QuestionBankCreateDto
    {
        public string Name { get; set; }
        public string Language { get; set; }
        // fk user
        public DateTime QuestionCreateDue { get; set; }
        public DateTime QuestionReviewDue { get; set; }
    }
}
