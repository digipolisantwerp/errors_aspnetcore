using System;
using Toolbox.Errors.Internal;

namespace Toolbox.Errors.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base(Defaults.UnauthorizedException.Message)
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(Error error) : base(error, Defaults.UnauthorizedException.Message)
        {
        }
    }
}
