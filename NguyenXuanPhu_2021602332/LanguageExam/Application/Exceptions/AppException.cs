using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public abstract class AppException : Exception
    {
        public virtual int StatusCode { get; } = 500;

        public AppException(string message) : base(message) { }
    }
}
