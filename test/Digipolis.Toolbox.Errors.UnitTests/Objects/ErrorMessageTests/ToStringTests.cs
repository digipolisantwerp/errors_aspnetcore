using System;
using Xunit;

namespace Digipolis.Toolbox.Errors.UnitTests.Objects.ErrorMessageTests
{
    public class ToStringTests
    {
        [Fact]
        private void ToStringContainsClassName()
        {
            var errorMessage = new ErrorMessage("aKey", "aMessage");
            Assert.Contains("ErrorMessage", errorMessage.ToString());
        }

        [Fact]
        private void ToStringContainsKey()
        {
            var errorMessage = new ErrorMessage("aKey", "aMessage");
            Assert.Contains("Key = aKey", errorMessage.ToString());
        }

        [Fact]
        private void ToStringContainsMessage()
        {
            var errorMessage = new ErrorMessage("aKey", "aMessage");
            Assert.Contains("aMessage", errorMessage.ToString());
        }
    }
}
