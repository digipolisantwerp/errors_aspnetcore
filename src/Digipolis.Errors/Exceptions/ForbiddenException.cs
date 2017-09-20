using System;
using System.Collections.Generic;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors.Exceptions
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(string message = Defaults.ForbiddenException.Title, string code = Defaults.ForbiddenException.Code, Exception exception = null, Dictionary<string, IEnumerable<string>> messages = null)
            : base(message, code, exception, messages)
        { }
    }
}
