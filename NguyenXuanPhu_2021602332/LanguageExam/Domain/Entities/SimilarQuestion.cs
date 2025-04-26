using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SimilarQuestion
    {
        public Guid ContentBlockId1 { get; set; }    
        public Guid ContentBlockId2 { get; set; }
        public float Score { get; set; }
        public string Reason { get; set; }
    }
}
