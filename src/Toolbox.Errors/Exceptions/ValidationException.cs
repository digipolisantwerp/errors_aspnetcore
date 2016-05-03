using System;
using Toolbox.Errors.Internal;

namespace Toolbox.Errors.Exceptions
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
