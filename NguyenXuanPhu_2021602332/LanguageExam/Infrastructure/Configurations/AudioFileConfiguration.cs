﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class AudioFileConfiguration : IEntityTypeConfiguration<AudioFile>
    {
        public void Configure(EntityTypeBuilder<AudioFile> builder)
        {
            builder.ToTable("AudioFile");
            builder.HasKey(a => a.Id);


            
        }
    }
}
