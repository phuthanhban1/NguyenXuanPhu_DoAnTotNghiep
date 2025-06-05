using Application.Dtos.QuestionDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockUpdateDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }

        // foreign key audio file
        public IFormFile? AudioFile { get; set; }

        //// foreign key image file
        public IFormFile? ImageFile { get; set; }

        // foreign key question level
        //public Guid QuestionTypeId { get; set; }

        public List<QuestionCreateDto> Questions { get; set; }
    }
}
