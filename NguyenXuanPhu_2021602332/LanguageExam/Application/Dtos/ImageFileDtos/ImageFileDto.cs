using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ImageFileDtos
{
    public class ImageFileDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Byte[] FileData { get; set; }
        public string ContentType { get; set; }
    }
}
