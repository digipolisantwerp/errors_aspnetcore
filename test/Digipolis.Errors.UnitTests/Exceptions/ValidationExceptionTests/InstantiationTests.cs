using System;
using System.Collections.Generic;
using System.Linq;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Exceptions.ValidationExceptionTests
{
    public class InstantiationTests
    {
        [Fact]
        private void PropertiesAreDefaulted()
        {
            var ex = new ValidationException();
            Assert.Equal(Defaults.ValidationException.Title, ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void MessageIsSet()
        {
            var ex = new ValidationException("validation failed");
            Assert.Equal("validation failed", ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void CodeIsSet()
        {
            string code = "INVAL01";

            var ex = new ValidationException("validation failed", code);

            Assert.Same(code, ex.Code);
        }

        [Fact]
        private void MessageAndInnerExceptionAreSetInProperties()
        {
            var innerEx = new Exception("innerMessage");
            var ex = new ValidationException("validation failed", "INVAL01", innerEx);
            Assert.Equal("validation failed", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
        }

        [Fact]
        private void MessageAndInnerExceptionAndExtraParametersAreSetInProperties()
        {
            var messages = new Dictionary<string, IEnumerable<string>>();
            var message = new[] { "message1", "message2" };
            messages.Add("key1", message);
            var innerEx = new Exception("innerMessage");

            var ex = new ValidationException("validation failed", "INVAL01", innerEx, messages);
            Assert.Equal("validation failed", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
            Assert.Same(messages, ex.Messages);
        }
    }
}
