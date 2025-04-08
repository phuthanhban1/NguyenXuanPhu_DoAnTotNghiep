using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class District 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // foreign key province
        public Guid ProvinceId { get; set; }
        public Province Province { get; set; }
       
        public List<Ward> Wards { get; set; }
    }
    
}
