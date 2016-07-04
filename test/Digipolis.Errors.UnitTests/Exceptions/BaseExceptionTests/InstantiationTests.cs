using System;
using System.Linq;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Exceptions.BaseExceptionTests
{
    public class InstantiationTests
    {
        [Fact]
        private void MessageIsSetInPropertyAndErrorObject()
        {
            var ex = new BaseException("aMessage");
            Assert.Equal("aMessage", ex.Message);
            Assert.NotNull(ex.Error);
            Assert.Equal(1, ex.Error.Messages.Count());
            Assert.Equal("aMessage", ex.Error.Messages.First().Message);
        }

        [Fact]
        private void MessageAndInnerExceptionAreSetInPropertiesAndErrorObject()
        {
            var innerEx = new Exception("innerMessage");
            var ex = new BaseException("aMessage", innerEx);
            Assert.Equal("aMessage", ex.Message);
            Assert.Same(innerEx, ex.InnerException);
            Assert.NotNull(ex.Error);
            Assert.Equal(1, ex.Error.Messages.Count());
            Assert.Equal("aMessage", ex.Error.Messages.First().Message);
        }

        [Fact]
        private void ErrorIsSet()
        {
            var error = new Error("id");
            var ex = new BaseException(error);
            Assert.Same(error, ex.Error);
        }

        [Fact]
        private void ErrorAndMessageAreSet()
        {
            var error = new Error("id");
            var ex = new BaseException(error, message: "aMessage");
            Assert.Same(error, ex.Error);
            Assert.Equal("aMessage", ex.Message);
        }

        [Fact]
        private void ErrorAndInnerExceptionAreSet()
        {
            var innerEx = new Exception("inner");
            var error = new Error("id");
            var ex = new BaseException(error, innerException: innerEx);
            Assert.Same(error, ex.Error);
            Assert.Same(innerEx, ex.InnerException);
        }
    }
}
