using System.ComponentModel;

namespace Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsProcess { get; set; }
        public bool IsConfirm { get; set; }
        // created user
        public Guid CreatedUserId { get; set; }
        public User CreatedUser { get; set; }
        // review user
        public Guid ReviewedUserId { get; set; }
        public User ReviewedUser { get; set; }

        // foreign key question bank
        public Guid QuestionBankId { get; set; }
        public QuestionBank QuestionBank { get; set; }

        public List<QuestionType> QuestionLevels { get; set; }


    }
}
