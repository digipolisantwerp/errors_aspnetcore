using System;
using System.Collections.Generic;
using System.Linq;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Exceptions.NotFoundExceptionTests
{
    public class InstantiationTests
    {
        [Fact]
        private void PropertiesAreDefaulted()
        {
            var ex = new NotFoundException();
            Assert.Equal(Defaults.NotFoundException.Title, ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void MessageIsSet()
        {
            var ex = new NotFoundException("not found");
            Assert.Equal("not found", ex.Message);
            Assert.NotNull(ex.Messages);
        }

        [Fact]
        private void MessageAndInnerExceptionAreSetInProperties()
        {
            var innerEx = new Exception("innerMessage");
            var ex = new NotFoundException("not found", innerEx);
            Assert.Equal("not found", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
        }

        [Fact]
        private void MessageAndInnerExceptionAndExtraParametersAreSetInProperties()
        {
            var messages = new Dictionary<string, IEnumerable<string>>();
            var message = new[] { "message1", "message2" };
            messages.Add("key1", message);
            var innerEx = new Exception("innerMessage");

            var ex = new NotFoundException("not found", innerEx, messages);
            Assert.Equal("not found", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
            Assert.Same(messages, ex.Messages);
        }
    }
}
