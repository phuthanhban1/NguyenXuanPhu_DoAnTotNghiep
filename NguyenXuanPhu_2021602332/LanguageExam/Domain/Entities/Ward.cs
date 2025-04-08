using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ward 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // foreign key district
        public Guid DistrictId { get; set; }
        public District District { get; set; }

        public List<User> Users { get; set; }
    
    }
}
