﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ExamQuestionConstructConfiguration : IEntityTypeConfiguration<ExamQuestionConstruction>
    {
        public void Configure(EntityTypeBuilder<ExamQuestionConstruction> builder)
        {
            
        }
    }
}
