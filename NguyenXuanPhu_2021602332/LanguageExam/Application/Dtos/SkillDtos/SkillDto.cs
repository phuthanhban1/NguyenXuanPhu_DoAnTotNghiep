﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SkillDtos
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // created user
        public Guid CreatedUserId { get; set; }
        // review user
        public Guid ReviewedUserId { get; set; }
    }
   
}
