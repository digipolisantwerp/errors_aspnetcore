using System;
using System.Linq;
using Digipolis.Toolbox.Errors.Exceptions;
using Digipolis.Toolbox.Errors.Internal;
using Xunit;

namespace Digipolis.Toolbox.Errors.UnitTests.Exceptions.UnauthorizedExceptionTests
{
    public class InstantiationTests
    {
        [Fact]
        private void PropertiesAreDefaulted()
        {
            var ex = new UnauthorizedException();
            Assert.Equal(Defaults.UnauthorizedException.Message, ex.Message);
            Assert.NotNull(ex.Error);
            Assert.Equal(1, ex.Error.Messages.Count());
            Assert.Equal(Defaults.UnauthorizedException.Message, ex.Error.Messages.First().Message);
        }

        [Fact]
        private void MessageIsSet()
        {
            var ex = new UnauthorizedException("access denied");
            Assert.Equal("access denied", ex.Message);
            Assert.NotNull(ex.Error);
            Assert.Equal(1, ex.Error.Messages.Count());
            Assert.Equal("access denied", ex.Error.Messages.First().Message);
        }

        [Fact]
        private void ErrorIsSet()
        {
            var error = new Error("id");
            var ex = new UnauthorizedException(error);
            Assert.Equal(Defaults.UnauthorizedException.Message, ex.Message);
            Assert.Same(error, ex.Error);
        }
    }
}
