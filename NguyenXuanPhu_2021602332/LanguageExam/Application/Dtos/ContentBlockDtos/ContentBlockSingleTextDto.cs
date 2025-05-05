using Application.Dtos.AnswerDtos;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockSingleTextDto
    {
        public string TextContent { get; set; }
        //public bool IsConfirm { get; set; }
        public byte Level { get; set; }
        public byte Score { get; set; }
        //public bool IsUsed { get; set; }
        //public DateOnly CreatedDate { get; set; }
        //public DateOnly? UpdatedDate { get; set; }
        //public string? RejectionReason { get; set; }
        // foreign key audio file

        // foreign key question level
        public Guid QuestionTypeId { get; set; }
        public List<AnswerCreateDto> Answers { get; set; }
    }
}
