using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuestionBank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public DateOnly CreatedDate { get; set; }
        
        public byte Status { get; set; } // 0: chua bat dau, 1: dang thuc hien, 2: da hoan thanh, 3: da huy
        // fk user
        public Guid ManagerId { get; set; }
        public User Manager { get; set; }

        public List<Skill> Skills { get; set; }
        public List<ExamStruct> ExamStructs { get; set; }

    }
}
