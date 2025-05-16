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
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? IdCard { get; set; }
        public DateOnly? DateOfIssue { get; set; }
        public string? PlaceOfIssue { get; set; }
        public bool? Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Strict { get; set; }
        //foreign key ward
        public int? WardId { get; set; }
        // fk img: anh mat
        public string? ImageFaceBase64 { get; set; }
        // fk img: id card before
        public string? ImageIdCardBeforeBase64 { get; set; } 
        // fk img: id card after
        public string? ImageIdCardAfterBase64 { get; set; }
        


    }
}
