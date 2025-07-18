﻿using Application.Dtos.QuestionDtos;
using Application.Dtos.SimilarQuestions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public bool IsSingle { get; set; }
        public byte Status { get; set; }
        public string? RejectionReason { get; set; }
        public string? ImageBase64 { get; set; }
        public string? AudioBase64 { get; set; }
        public List<QuestionCreateDto> Questions { get; set; }
        public List<SimilarQuestionDto> SimilarQuestions { get; set; }
    }
}
