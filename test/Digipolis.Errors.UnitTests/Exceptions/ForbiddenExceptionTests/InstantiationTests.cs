using System;
using System.Collections.Generic;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Exceptions.ForbiddenExceptionTests
{
    public class InstantiationTests
    {
        [Fact]
        private void PropertiesAreDefaulted()
        {
            var ex = new ForbiddenException();
            Assert.Equal(Defaults.ForbiddenException.Title, ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void MessageIsSet()
        {
            var ex = new ForbiddenException("forbidden");
            Assert.Equal("forbidden", ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void CodeIsSet()
        {
            string code = "FORBID";

            var ex = new ForbiddenException("forbidden", code);

            Assert.Same(code, ex.Code);
        }

        [Fact]
        private void MessageAndInnerExceptionAreSetInProperties()
        {
            var innerEx = new Exception("innerMessage");
            var ex = new ForbiddenException("forbidden", "FORBID", innerEx);
            Assert.Equal("forbidden", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
        }

        [Fact]
        private void MessageAndInnerExceptionAndExtraInfoAreSetInProperties()
        {
            var messages = new Dictionary<string, IEnumerable<string>>();
            var message = new[] { "message1", "message2" };
            messages.Add("key1", message);
            var innerEx = new Exception("innerMessage");

            var ex = new ForbiddenException("forbidden", "FORBID",innerEx, messages);
            Assert.Equal("forbidden", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
            Assert.Same(messages, ex.Messages);
        }
    }
}
