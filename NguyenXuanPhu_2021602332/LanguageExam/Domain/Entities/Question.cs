﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public byte Score { get; set; }
        public List<Answer> Answers { get; set; }

        //foreign key content block
        public Guid ContentBlockId { get; set; }
        public ContentBlock ContentBlock { get; set; }

    }
}
