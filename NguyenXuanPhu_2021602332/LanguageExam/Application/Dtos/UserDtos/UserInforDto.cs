using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
    public class UserInforDto
    {
        public Guid Id { get; set; }
        public ExamFile Avatar {get; set;}
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Expertise { get; set; }
        public string Experience { get; set; }
    }
}
