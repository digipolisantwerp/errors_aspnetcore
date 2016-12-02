using System;
using System.Collections.Generic;
using System.Linq;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Exceptions.BaseExceptionTests
{
    public class InstantiationTests
    {
        [Fact]
        private void MessageIsSetInProperty()
        {
            var ex = new ExceptionTester(message: "aMessage");
            Assert.Equal("aMessage", ex.Message);
        }

        [Fact]
        private void CodeIsSet()
        {
            string code = "EXTST";

            var ex = new ExceptionTester(code:code);

            Assert.Same(code, ex.Code);
        }

        [Fact]
        private void MessageAndInnerExceptionAreSetInProperties()
        {
            var innerEx = new Exception("innerMessage");
            var ex = new ExceptionTester(message: "aMessage", exception: innerEx);
            Assert.Equal("aMessage", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
        }

        [Fact]
        private void MessageAndInnerExceptionAndExtraParametersAreSetInProperties()
        {
            var messages = new Dictionary<string, IEnumerable<string>>();
            var message = new[] { "message1", "message2"};
            messages.Add("key1", message);
            var innerEx = new Exception("innerMessage");

            var ex = new ExceptionTester("aMessage", "EXTST", innerEx, messages);
            Assert.Equal("aMessage", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
            Assert.Same(messages, ex.Messages);
        }
    }
}
