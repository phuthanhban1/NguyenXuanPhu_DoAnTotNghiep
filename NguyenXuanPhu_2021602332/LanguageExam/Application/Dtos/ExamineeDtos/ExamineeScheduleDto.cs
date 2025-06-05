using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamineeDtos
{
    public class ExamineeScheduleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Password { get; set; }
        public string? RoomName { get; set; }
        public string? ExamineeNumber { get; set; }
    }
}
