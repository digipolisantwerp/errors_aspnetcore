using System;
using System.Collections.Generic;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Exceptions.GatewayTimeoutTests
{
    public class InstantiationTests
    {
        [Fact]
        private void PropertiesAreDefaulted()
        {
            var ex = new GatewayTimeoutException();
            Assert.Equal(Defaults.GatewayTimeoutException.Title, ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void MessageIsSet()
        {
            var ex = new GatewayTimeoutException("gateway timeout");
            Assert.Equal("gateway timeout", ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void CodeIsSet()
        {
            string code = "GTWYTO";

            var ex = new GatewayTimeoutException("gateway timeout", code);

            Assert.Same(code, ex.Code);
        }

        [Fact]
        private void MessageAndInnerExceptionAreSetInProperties()
        {
            var innerEx = new Exception("innerMessage");
            var ex = new GatewayTimeoutException("gateway timeout", "GTWYTO", innerEx);
            Assert.Equal("gateway timeout", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
        }

        [Fact]
        private void MessageAndInnerExceptionAndExtraParametersAreSetInProperties()
        {
            var messages = new Dictionary<string, IEnumerable<string>>();
            var message = new[] { "message1", "message2" };
            messages.Add("key1", message);
            var innerEx = new Exception("innerMessage");

            var ex = new GatewayTimeoutException("gateway timeout", "GTWYTO",innerEx, messages);
            Assert.Equal("gateway timeout", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
            Assert.Same(messages, ex.Messages);
        }
    }
}
