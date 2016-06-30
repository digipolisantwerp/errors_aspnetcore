using System;
using System.Linq;
using Digipolis.Toolbox.Errors.Exceptions;
using Digipolis.Toolbox.Errors.Internal;
using Xunit;

namespace Digipolis.Toolbox.Errors.UnitTests.Exceptions.ValidationExceptionTests
{
    public class InstantiationTests
    {
        [Fact]
        private void PropertiesAreDefaulted()
        {
            var ex = new ValidationException();
            Assert.Equal(Defaults.ValidationException.Message, ex.Message);
            Assert.NotNull(ex.Error);
            Assert.Equal(1, ex.Error.Messages.Count());
            Assert.Equal(Defaults.ValidationException.Message, ex.Error.Messages.First().Message);
        }

        [Fact]
        private void MessageIsSet()
        {
            var ex = new ValidationException("validation failed");
            Assert.Equal("validation failed", ex.Message);
            Assert.NotNull(ex.Error);
            Assert.Equal(1, ex.Error.Messages.Count());
            Assert.Equal("validation failed", ex.Error.Messages.First().Message);
        }

        [Fact]
        private void ErrorIsSet()
        {
            var error = new Error("id");
            var ex = new ValidationException(error);
            Assert.Equal(Defaults.ValidationException.Message, ex.Message);
            Assert.Same(error, ex.Error);
        }
    }
}
