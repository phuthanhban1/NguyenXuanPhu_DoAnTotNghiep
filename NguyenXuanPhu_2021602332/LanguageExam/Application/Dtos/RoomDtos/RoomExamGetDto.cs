using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.RoomDtos
{
    public class RoomExamGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte Amount { get; set; }
        public int ExamineeAmount { get; set; }
    }
}
