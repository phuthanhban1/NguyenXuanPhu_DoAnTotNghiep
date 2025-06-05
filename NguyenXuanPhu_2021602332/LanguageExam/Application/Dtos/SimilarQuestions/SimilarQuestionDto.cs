using Application.Dtos.QuestionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SimilarQuestions
{
    public class SimilarQuestionDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public byte Status { get; set; }
        public bool IsSingle { get; set; }
        public string? RejectionReason { get; set; }
        public string? ImageBase64 { get; set; }
        public string? AudioBase64 { get; set; }
        public List<QuestionCreateDto> Questions { get; set; }
        public string Reason { get; set; }
    }
}
