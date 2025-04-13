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
        public bool Gener { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Strict { get; set; }

        //foreign key ward
        public int WardId { get; set; }
        //public Ward Ward { get; set; }

        // fk img: anh mat
        public Guid ImageFaceId { get; set; }
        //public ImageFile ImageFace { get; set; }

        // fk img: id card before
        public Guid ImageIdCardBeforeId { get; set; }
        //public ImageFile ImageIdCardBefore { get; set; }

        // fk img: id card after
        public Guid ImageIdCardAfterId { get; set; }
    }
}
