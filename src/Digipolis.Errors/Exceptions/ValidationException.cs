using System;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException() : base(Defaults.ValidationException.Message)
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(Error error) : base(error, Defaults.ValidationException.Message)
        {
        }
    }
}
