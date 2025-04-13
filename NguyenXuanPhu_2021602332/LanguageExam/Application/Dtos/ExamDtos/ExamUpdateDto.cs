﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamDtos
{
    public class ExamUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public string Password { get; set; }
        public int Fee { get; set; }
        public bool IsActive { get; set; }
        // id created exam question
        public Guid CreatedQuestionUserId { get; set; }
        
    }
}
