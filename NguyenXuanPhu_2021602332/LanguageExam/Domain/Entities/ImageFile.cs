using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ImageFile
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string ContentType { get; set; }
        public Question? Question { get; set; }
        public User ImageFace { get; set; }
        public User ImageIdCardBefore { get; set; }
        public User ImageIdCardAfter { get; set; }


    }
}
