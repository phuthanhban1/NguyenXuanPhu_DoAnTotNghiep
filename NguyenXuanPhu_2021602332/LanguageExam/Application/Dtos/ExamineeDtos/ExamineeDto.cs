using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamineeDtos
{
    public class ExamineeDto
    {
        public Guid ExamId { get; set; }
        //public Exam Exam { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        //public User User { get; set; }
        public int? Location { get; set; }
        public Guid? RoomId { get; set; }
        public string? RoomName { get; set; }
        public string? ExamineeNumber { get; set; }
    }
}
