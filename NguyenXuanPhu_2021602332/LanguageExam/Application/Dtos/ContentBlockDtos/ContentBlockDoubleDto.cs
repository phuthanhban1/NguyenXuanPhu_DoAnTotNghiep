using Application.Dtos.AnswerDtos;
using Application.Dtos.QuestionDtos;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockDoubleDto
    {
        public string TextContent { get; set; }
        public byte Level { get; set; }
        public List<QuestionCreateDto> Questions { get; set; }

        // foreign key question level
        public Guid QuestionTypeId { get; set; }
        
    }
}
