using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }

        public List<Answer> Answers { get; set; }

        //foreign key imgae file
        public Guid? ImageFileId { get; set; }
        public File? ImageFile { get; set; }

        //foreign key content block
        public Guid ContentBlockId { get; set; }
        public ContentBlock ContentBlock { get; set; }

    }
}
