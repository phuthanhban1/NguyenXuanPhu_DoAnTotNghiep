using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockCreateDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
       
        public byte Level { get; set; }
        //public bool IsConfirm { get; set; }
        //public bool IsUsed { get; set; }
        //public DateOnly CreatedDate { get; set; }
        //public DateOnly? UpdatedDate { get; set; }
        //public string? RejectionReason { get; set; }
        // foreign key audio file
        public IFormFile? AudioFile { get; set; }

        // foreign key image file
        public IFormFile? ImageFile { get; set; }

        // foreign key question level
        public Guid QuestionTypeId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
