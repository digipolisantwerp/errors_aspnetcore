using System;
using System.Collections.Generic;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message = Defaults.NotFoundException.Title, string code =Defaults.NotFoundException.Code, Exception exception = null, Dictionary < string, IEnumerable<string>> messages = null )
            : base(message,code, exception, messages)
        {}
    }
}
