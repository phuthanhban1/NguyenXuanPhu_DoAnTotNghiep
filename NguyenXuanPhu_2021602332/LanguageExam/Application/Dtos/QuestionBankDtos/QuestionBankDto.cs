using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.QuestionBankDtos
{
    public class QuestionBankDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime QuestionCreateDue { get; set; }
        public DateTime QuestionReviewDue { get; set; }

        // fk user
        public Guid ManagerId { get; set; }
        public User Manager { get; set; }
    }
}
