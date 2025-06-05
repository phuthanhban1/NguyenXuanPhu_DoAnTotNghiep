using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Examinee
    {
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int? Location { get; set; }
        public bool IsExamTaken { get; set; }
        public Guid? RoomId { get; set; }
        public Room? Room { get; set; }
        public int? ReadingScore { get; set; }
        public int? ListeningScore { get; set; }
        public int? SpeakingScore { get; set; }
        public int? WritingScore { get; set; }
        public string? ExamineeNumber { get; set; }
        public List<DetailResult>? DetailResults { get; set; }
    }
}
