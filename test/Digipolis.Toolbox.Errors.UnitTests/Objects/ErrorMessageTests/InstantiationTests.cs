using System;
using Digipolis.Toolbox.Errors.Internal;
using Xunit;

namespace Digipolis.Toolbox.Errors.UnitTests.Objects.ErrorMessageTests
{
    public class InstantiationTests
    {
        [Fact]
        private void KeyIsSet()
        {
            var errorMessage = new ErrorMessage("key", "message");
            Assert.Equal("key", errorMessage.Key);
        }

        [Fact]
        private void MessageIsSet()
        {
            var errorMessage = new ErrorMessage("key", "message");
            Assert.Equal("message", errorMessage.Message);
        }

        [Fact]
        private void KeyNullRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ErrorMessage(null, "message"));
            Assert.Equal("key", ex.ParamName);
        }

        [Fact]
        private void MessageNullSetsToNullString()
        {
            var errorMessage = new ErrorMessage("key", null);
            Assert.Equal(Defaults.ErrorMessage.NullString, errorMessage.Message);
        }
    }
}
