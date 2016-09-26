using System;
using System.Collections.Generic;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message = Defaults.NotFoundException.Title, Exception exception = null, Dictionary < string, IEnumerable<string>> messages = null )
            : base(message, exception, messages)
        {}
    }
}
