using Application.Dtos.AnswerDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockSingleFileDto
    {
        public string? TextContent { get; set; }
        public byte Level { get; set; }
        public byte Score { get; set; }
        public IFormFile? ImageFile { get; set; }
        public IFormFile? AudioFile { get; set; }
        public Guid QuestionTypeId { get; set; }
        public List<AnswerCreateDto> Answers { get; set; }
    }
}
