using Digipolis.Errors.Internal;
using System;
using System.Collections.Generic;

namespace Digipolis.Errors.Exceptions
{
    public class TooManyRequestsException : BaseException
    {
        public TooManyRequestsException(string message = Defaults.TooManyRequestsException.Title, string code = Defaults.TooManyRequestsException.Code, Exception exception = null, Dictionary<string, IEnumerable<string>> messages = null)
            : base(message, code, exception, messages)
        { }
    }
}
