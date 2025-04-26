using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
    public class UserUpdateDto : BaseUserDto
    {
        public Guid Id { get; set; }
        // fk img: anh mat
        public IFormFile ImageFace { get; set; }
        //public ImageFile ImageFace { get; set; }

        // fk img: id card before
        public IFormFile ImageIdCardBefore { get; set; }

        // fk img: id card after
        public IFormFile ImageIdCardAfter { get; set; }
    }
}
