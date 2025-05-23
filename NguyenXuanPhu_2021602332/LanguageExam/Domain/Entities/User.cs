﻿namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? IdCard { get; set; }
        public DateOnly? DateOfIssue { get; set; }
        public string? PlaceOfIssue { get; set; }
        public bool? Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Password { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Strict { get; set; }
        public bool IsActive { get; set; } = true;

        //foreign key ward
        public int? WardId { get; set; }
        public Ward? Ward { get; set; }
        // foreign key role 
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }

        // fk img: anh mat
        public Guid? ImageFaceId { get; set; }
        public ExamFile? ImageFace { get; set; }

        // fk img: id card before
        public Guid? ImageIdCardBeforeId { get; set; }
        public ExamFile? ImageIdCardBefore { get; set; }

        // fk img: id card after
        public Guid? ImageIdCardAfterId { get; set; }
        public ExamFile? ImageIdCardAfter { get; set; }

        public List<Exam>? ManagedExam { get; set; }
        public List<Exam>? CreatedQuestionExam { get; set; }

        public List<Skill>? CreatedQuestions { get; set; }
        public List<Skill>? ReviewedQuestions { get; set; }
        public List<QuestionBank>? QuestionBanks { get; set; }

        public List<ExamStruct>? ExamStructs { get; set; }
        public List<Examinee>? Examinees { get; set; }
    }
}
