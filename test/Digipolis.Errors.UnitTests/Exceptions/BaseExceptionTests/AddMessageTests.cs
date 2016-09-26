using System;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;
using System.Linq;

namespace Digipolis.Errors.UnitTests.Exceptions.BaseExceptionTests
{
    public class AddMessageTests
    {
        [Fact]
        private void MessageIsAddedToMessagesCollectionWithDefaultKey()
        {
            var ex = new ExceptionTester();
            ex.AddMessage("aMessage");

            Assert.Equal(1, ex.Messages.Count);
            Assert.Contains("aMessage", ex.Messages.First().Value);
            Assert.Equal(Defaults.ErrorMessage.Key, ex.Messages.First().Key);
        }

        [Fact]
        private void KeyAndMessageAreAddedToMessagesCollection()
        {
            var ex = new ExceptionTester();
            ex.AddMessage("aKey", "aMessage");

            Assert.Equal(1, ex.Messages.Count);
            Assert.Equal("aKey", ex.Messages.First().Key);
            Assert.Contains("aMessage", ex.Messages.First().Value);
        }

        [Fact]
        private void NullKeyThrowsArgumentNullException()
        {
            var ex = new ExceptionTester();
            var result = Assert.Throws<ArgumentNullException>(() => ex.AddMessage(null, "aMessage"));
            Assert.Equal("key", result.ParamName);
        }

        [Fact]
        private void NullMessageWithValidKeyIsNotAddedToMessagesCollection()
        {
            var ex = new ExceptionTester();
            ex.AddMessage("aKey", null);
            Assert.Equal(0, ex.Messages.Count);
        }

        [Fact]
        private void NullMessagesOnlyIsNotAddedToMessagesCollection()
        {
            var ex = new ExceptionTester();
            ex.AddMessage(null);
            ex.AddMessage(string.Empty);
            Assert.Equal(0, ex.Messages.Count);
        }
    }
}
