using System;
using Toolbox.Errors.Internal;

namespace Toolbox.Errors.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException() : base(Defaults.ValidationException.Message)
        {
            HttpStatusCode = Defaults.ValidationException.HttpStatusCode;
        }

        public ValidationException(string message) : base(message)
        {
            HttpStatusCode = Defaults.ValidationException.HttpStatusCode;
        }

        public ValidationException(Error error) : base(error, Defaults.ValidationException.Message)
        {
            HttpStatusCode = Defaults.ValidationException.HttpStatusCode;
        }
    }
}
