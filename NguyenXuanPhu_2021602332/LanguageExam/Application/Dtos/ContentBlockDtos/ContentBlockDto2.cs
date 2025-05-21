using Application.Dtos.QuestionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockDto2
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public bool IsSingle { get; set; }
        public string? RejexctionReason { get; set; }
        public string? ImageBase64 { get; set; }
        public string? AudioBase64 { get; set; }
        public List<QuestionCreateDto2> Questions { get; set; }
    }
}
