﻿using System.ComponentModel;

namespace Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // created user
        public Guid? CreatedUserId { get; set; }
        public User? CreatedUser { get; set; }
        public DateTime? CreateDue { get; set; }
        public DateTime? ReviewDue { get; set; }
        // review user
        public Guid? ReviewedUserId { get; set; }
        public User? ReviewedUser { get; set; }

        // foreign key question bank
        public Guid QuestionBankId { get; set; }
        public QuestionBank QuestionBank { get; set; }

        public List<QuestionType> QuestionTypes { get; set; }


    }
}
