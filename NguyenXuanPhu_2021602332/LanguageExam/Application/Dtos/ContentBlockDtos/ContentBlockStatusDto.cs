using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockStatusDto
    {
        public Guid Id { get; set; }
        public byte Status { get; set; }
    }
}
