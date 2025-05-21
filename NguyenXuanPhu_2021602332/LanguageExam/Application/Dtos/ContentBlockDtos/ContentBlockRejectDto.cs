using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContentBlockDtos
{
    public class ContentBlockRejectDto
    {
        public Guid Id { get; set; }
        public string RejectionReason { get; set; }
        
    }
}
