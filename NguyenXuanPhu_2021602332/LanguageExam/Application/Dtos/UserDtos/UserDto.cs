using Application.Dtos.ImageFileDtos;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
    public class UserDto : BaseUserDto
    {
        public Guid Id { get; set; }

        public ImageFileDto ImageFace { get; set; }
       
        public ImageFileDto ImageIdCardBefore { get; set; }

        public ImageFileDto ImageIdCardAfter { get; set; }
        public string Address { get; set; }


    }
}
