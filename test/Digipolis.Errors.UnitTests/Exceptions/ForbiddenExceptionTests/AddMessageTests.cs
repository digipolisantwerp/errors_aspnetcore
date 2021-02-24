using System;
using System.Linq;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Exceptions.ForbiddenExceptionTests
{
    public class AddMessageTests
    {
        [Fact]
        private void MessageIsAddedToMessagesCollectionWithDefaultKey()
        {
            var ex = new ForbiddenException();
            ex.AddMessage("aMessage");

            Assert.Single(ex.Messages);
            Assert.Contains("aMessage", ex.Messages.First().Value);
            Assert.Equal(Defaults.ErrorMessage.Key, ex.Messages.First().Key);
        }

        [Fact]
        private void KeyAndMessageAreAddedToMessagesCollection()
        {
            var ex = new ForbiddenException();
            ex.AddMessage("aKey", "aMessage");

            Assert.Single(ex.Messages);
            Assert.Equal("aKey", ex.Messages.First().Key);
            Assert.Contains("aMessage", ex.Messages.First().Value);
        }

        [Fact]
        private void NullKeyThrowsArgumentNullException()
        {
            var ex = new ForbiddenException();
            var result = Assert.Throws<ArgumentNullException>(() => ex.AddMessage(null, "aMessage"));
            Assert.Equal("key", result.ParamName);
        }

        [Fact]
        private void NullMessageWithValidKeyIsNotAddedToMessagesCollection()
        {
            var ex = new ForbiddenException();
            ex.AddMessage("aKey", null);
            Assert.Empty(ex.Messages);
        }

        [Fact]
        private void NullMessagesOnlyIsNotAddedToMessagesCollection()
        {
            var ex = new ForbiddenException();
            ex.AddMessage(null);
            ex.AddMessage(string.Empty);
            Assert.Empty(ex.Messages);
        }

        [Fact]
        private void DefaultEmptyKeyAddsToCollection()
        {
            var ex = new ForbiddenException();
            ex.AddMessage(Defaults.ErrorMessage.Key, "aMessage");

            Assert.Single(ex.Messages);
            Assert.Contains("aMessage", ex.Messages.First().Value);
        }
    }
}
