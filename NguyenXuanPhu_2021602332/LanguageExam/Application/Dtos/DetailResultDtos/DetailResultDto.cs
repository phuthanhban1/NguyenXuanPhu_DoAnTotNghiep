using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.DetailResultDtos
{
    public class DetailResultDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string ExamineeNumber { get; set; }
        public int? ListeningScore { get; set; }
        public int? ReadingScore { get; set; }
    }
}
