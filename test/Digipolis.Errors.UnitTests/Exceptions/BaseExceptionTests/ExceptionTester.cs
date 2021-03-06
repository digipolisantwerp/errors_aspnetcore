﻿using System;
using System.Collections.Generic;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors.UnitTests.Exceptions.BaseExceptionTests
{
    internal class ExceptionTester : BaseException
    {
        public ExceptionTester(string message = Defaults.ValidationException.Title, string code = Defaults.ValidationException.Code, Exception exception = null, Dictionary<string, IEnumerable<string>> messages = null)
            : base(message,code, exception, messages)
        { }
    }
}