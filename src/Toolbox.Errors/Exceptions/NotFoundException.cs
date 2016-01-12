using System;
using Toolbox.Errors.Internal;

namespace Toolbox.Errors.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base(Defaults.NotFoundException.Message)
        {
            HttpStatusCode = Defaults.NotFoundException.HttpStatusCode;
        }

        public NotFoundException(string message) : base(message)
        {
            HttpStatusCode = Defaults.NotFoundException.HttpStatusCode;
        }

        public NotFoundException(Error error) : base(error, Defaults.NotFoundException.Message)
        {
            HttpStatusCode = Defaults.NotFoundException.HttpStatusCode;
        }
    }
}
