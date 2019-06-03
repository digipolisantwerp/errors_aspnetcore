using System;
using System.Collections.Generic;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Exceptions.BadGatewayExceptionTests
{
    public class InstantiationTests
    {
        [Fact]
        private void PropertiesAreDefaulted()
        {
            var ex = new BadGatewayException();
            Assert.Equal(Defaults.BadGatewayException.Title, ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void MessageIsSet()
        {
            var ex = new BadGatewayException("bad gateway");
            Assert.Equal("bad gateway", ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void CodeIsSet()
        {
            string code = "BADGTWY";

            var ex = new BadGatewayException("bad gateway", code);

            Assert.Same(code, ex.Code);
        }

        [Fact]
        private void MessageAndInnerExceptionAreSetInProperties()
        {
            var innerEx = new Exception("innerMessage");
            var ex = new BadGatewayException("bad gateway", "BADGTWY", innerEx);
            Assert.Equal("bad gateway", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
        }

        [Fact]
        private void MessageAndInnerExceptionAndExtraParametersAreSetInProperties()
        {
            var messages = new Dictionary<string, IEnumerable<string>>();
            var message = new[] { "message1", "message2" };
            messages.Add("key1", message);
            var innerEx = new Exception("innerMessage");

            var ex = new BadGatewayException("bad gateway", "BADGTWY", innerEx, messages);
            Assert.Equal("bad gateway", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
            Assert.Same(messages, ex.Messages);
        }
    }
}
