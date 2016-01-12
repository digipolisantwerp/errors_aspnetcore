using System;
using Toolbox.Errors.Internal;

namespace Toolbox.Errors.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base(Defaults.UnauthorizedException.Message)
        {
            HttpStatusCode = Defaults.UnauthorizedException.HttpStatusCode;
        }

        public UnauthorizedException(string message) : base(message)
        {
            HttpStatusCode = Defaults.UnauthorizedException.HttpStatusCode;
        }

        public UnauthorizedException(Error error) : base(error, Defaults.UnauthorizedException.Message)
        {
            HttpStatusCode = Defaults.UnauthorizedException.HttpStatusCode;
        }
    }
}
