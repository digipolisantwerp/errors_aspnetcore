using System;
using System.Linq;
using Digipolis.Toolbox.Errors.Exceptions;
using Digipolis.Toolbox.Errors.Internal;
using Xunit;

namespace Digipolis.Toolbox.Errors.UnitTests.Exceptions.NotFoundExceptionTests
{
    public class InstantiationTests
    {
        [Fact]
        private void PropertiesAreDefaulted()
        {
            var ex = new NotFoundException();
            Assert.Equal(Defaults.NotFoundException.Message, ex.Message);
            Assert.NotNull(ex.Error);
            Assert.Equal(1, ex.Error.Messages.Count());
            Assert.Equal(Defaults.NotFoundException.Message, ex.Error.Messages.First().Message);
        }

        [Fact]
        private void MessageIsSet()
        {
            var ex = new NotFoundException("not found");
            Assert.Equal("not found", ex.Message);
            Assert.NotNull(ex.Error);
            Assert.Equal(1, ex.Error.Messages.Count());
            Assert.Equal("not found", ex.Error.Messages.First().Message);
        }

        [Fact]
        private void ErrorIsSet()
        {
            var error = new Error("id");
            var ex = new NotFoundException(error);
            Assert.Equal(Defaults.NotFoundException.Message, ex.Message);
            Assert.Same(error, ex.Error);
        }
    }
}
