﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.QuestionTypeDtos
{
    public class QuestionTypeBase
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsSingle { get; set; }
        public bool HasImage { get; set; }
    }
}
