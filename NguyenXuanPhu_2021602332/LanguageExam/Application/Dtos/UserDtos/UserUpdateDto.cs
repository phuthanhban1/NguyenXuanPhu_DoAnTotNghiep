using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string IdCard { get; set; }
        public DateOnly? DateOfIssue { get; set; }
        public string? PlaceOfIssue { get; set; }
        public bool Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Strict { get; set; }

        ////foreign key ward
        public int WardId { get; set; }

        //// fk img: anh mat
        public IFormFile ImageFace { get; set; }

        //// fk img: id card before
        public IFormFile ImageIdCardBefore { get; set; }
        ////public ImageFile ImageIdCardBefore { get; set; }

        //// fk img: id card after
        public IFormFile ImageIdCardAfter { get; set; }
        //public ImageFile ImageIdCardAfter { get; set; }
    }
}
