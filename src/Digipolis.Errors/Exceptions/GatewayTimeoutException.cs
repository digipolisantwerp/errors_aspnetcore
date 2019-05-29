using Digipolis.Errors.Internal;
using System;
using System.Collections.Generic;

namespace Digipolis.Errors.Exceptions
{
    public class GatewayTimeoutException : BaseException
    {
        public GatewayTimeoutException(string message = Defaults.GatewayTimeoutException.Title, string code= Defaults.GatewayTimeoutException.Code, Exception ex = null, Dictionary<string, IEnumerable<string>> messages = null)
            : base(message, code, ex, messages)
        {

        }
    }
}
