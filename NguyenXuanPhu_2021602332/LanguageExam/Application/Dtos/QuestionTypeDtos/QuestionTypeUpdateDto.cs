﻿using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.QuestionTypeDtos
{
    public class QuestionTypeUpdateDto : QuestionTypeBase
    {
        public Guid Id { get; set; }
        
    }
}
