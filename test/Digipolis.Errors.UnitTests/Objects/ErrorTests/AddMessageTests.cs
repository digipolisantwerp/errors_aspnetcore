using System;
using System.Linq;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.Objects.ErrorTests
{
    public class AddMessageTests
    {
        [Fact]
        private void MessageIsAddedToMessagesCollectionWithDefaultKey()
        {
            var error = new Error("id");

            error.AddMessage("aMessage");

            Assert.Equal(1, error.Messages.Count());
            Assert.Equal("aMessage", error.Messages.First().Message);
            Assert.Equal(Defaults.ErrorMessage.Key, error.Messages.First().Key);
        }

        [Fact]
        private void KeyAndMessageAreAddedToMessagesCollection()
        {
            var error = new Error("id");

            error.AddMessage("aKey", "aMessage");

            Assert.Equal(1, error.Messages.Count());
            Assert.Equal("aKey", error.Messages.First().Key);
            Assert.Equal("aMessage", error.Messages.First().Message);
        }

        [Fact]
        private void NullKeyThrowsArgumentNullException()
        {
            var error = new Error("id");

            var ex = Assert.Throws<ArgumentNullException>(() => error.AddMessage(null, "aMessage"));
            Assert.Equal("key", ex.ParamName);
        }

        [Fact]
        private void NullMessageWithValidKeyIsAddedToMessagesCollection()
        {
            var error = new Error("id");

            error.AddMessage("aKey", null);

            Assert.Equal(1, error.Messages.Count());
            Assert.Equal("aKey", error.Messages.First().Key);
            Assert.Equal(Defaults.ErrorMessage.NullString, error.Messages.First().Message);
        }

        [Fact]
        private void NullMessageOnlyIsNotAddedToMessagesCollection()
        {
            var error = new Error("id");

            string nullString = null;
            error.AddMessage(nullString);

            Assert.Equal(0, error.Messages.Count());
        }
    }
}
