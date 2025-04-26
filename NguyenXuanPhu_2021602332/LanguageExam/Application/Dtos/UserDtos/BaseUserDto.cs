﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
    public class BaseUserDto
    {
        public bool Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Strict { get; set; }
        public int WardId { get; set; }

        


        
    }
}
