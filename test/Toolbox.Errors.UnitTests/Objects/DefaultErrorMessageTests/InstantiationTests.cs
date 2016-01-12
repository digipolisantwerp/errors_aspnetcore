using System;
using Toolbox.Errors.Internal;
using Xunit;

namespace Toolbox.Errors.UnitTests.Objects.DefaultErrorMessageTests
{
    public class InstantiationTests
    {
        [Fact]
        private void MessageIsSet()
        {
            var errorMessage = new DefaultErrorMessage("aMessage");
            Assert.Equal("aMessage", errorMessage.Message);
        }

        [Fact]
        private void MessageNullIsSetToNullString()
        {
            var errorMessage = new DefaultErrorMessage(null);
            Assert.Equal(Defaults.ErrorMessage.NullString, errorMessage.Message);
        }

        [Fact]
        private void DefaultKeyIsSet()
        {
            var errorMessage = new DefaultErrorMessage("aMessage");
            Assert.Equal(Defaults.ErrorMessage.Key, errorMessage.Key);
        }
    }
}
