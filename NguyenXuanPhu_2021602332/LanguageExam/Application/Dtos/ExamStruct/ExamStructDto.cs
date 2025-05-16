using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ExamStruct
{
    public class ExamStructDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserCreateId { get; set; }
        
    }
}
