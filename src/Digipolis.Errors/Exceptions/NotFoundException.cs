using System;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base(Defaults.NotFoundException.Message)
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(Error error) : base(error, Defaults.NotFoundException.Message)
        {
        }
    }
}
