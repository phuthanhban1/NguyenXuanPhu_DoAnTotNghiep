using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFoundException : AppException
    {
        public override int StatusCode => 404;

        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception e) : base(message, e) { }
    }
}
