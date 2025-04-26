using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ImageFileDtos
{
    public class ImageFileDto : ImageFileUpdateDto
    {
        public Guid Id { get; set; }
        
    }
}
