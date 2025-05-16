using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamStruct
{
    public class ExamStructCreateDto
    {
        public string Name { get; set; }
        public Guid QuestionBankId { get; set; }
    }
}
