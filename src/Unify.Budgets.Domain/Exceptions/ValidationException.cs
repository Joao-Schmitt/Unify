using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unify.Budgets.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public string Code { get; }
        public object Details { get; }

        public ValidationException(string message)
            : base(message) { }

        public ValidationException(string code, string message)
            : base(message)
        {
            Code = code;
        }

        public ValidationException(string message, object details)
            : base(message)
        {
            Details = details;
        }
    }


}
