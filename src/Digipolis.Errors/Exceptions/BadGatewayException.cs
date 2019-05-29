using Digipolis.Errors.Internal;
using System;
using System.Collections.Generic;

namespace Digipolis.Errors.Exceptions
{
    public class BadGatewayException : BaseException
    {
        public BadGatewayException(string message = Defaults.BadGatewayException.Title, string code = Defaults.BadGatewayException.Code, Exception ex = null, Dictionary<string, IEnumerable<string>> messages = null)
            : base(message, code, ex, messages)
        { }
    }
}
