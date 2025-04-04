using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ImageFile : AudioFile
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
