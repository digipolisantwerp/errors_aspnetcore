using System;
using System.Collections.Generic;
using System.Linq;
using Digipolis.Toolbox.Errors.Internal;
using Xunit;

namespace Digipolis.Toolbox.Errors.UnitTests.Objects.ErrorTests
{
    public class AddMessagesTests
    {
        [Fact]
        private void MessagesAreAddedToMessagesCollection()
        {
            var message1 = "message1";
            var message2 = "messages2";
            var messages = new string[] { message1, message2 };

            var error = new Error("id");
            error.AddMessages(messages);

            Assert.Equal(2, error.Messages.Count());

            var values = error.Messages.Select(m => m.Message);
            var keys = error.Messages.Select(m => m.Key);

            Assert.Contains(message1, values);
            Assert.Contains(message2, values);
            Assert.All(keys, k => Assert.Equal(Defaults.ErrorMessage.Key, k));
        }

        [Fact]
        private void NullMessagesCollectionIsNotAddedToMessagesCollection()
        {
            var error = new Error("id");

            IEnumerable<string> nullMessages = null;
            error.AddMessages(nullMessages);

            Assert.Equal(0, error.Messages.Count());
        }

        [Fact]
        private void NullMessagesInCollectionAreNotAddedToMessagesCollection()
        {
            var messages = new string[] { "message1", null };

            var error = new Error("id");
            error.AddMessages(messages);

            Assert.Equal(1, error.Messages.Count());

            var values = error.Messages.Select(m => m.Message);

            Assert.Contains("message1", values);
        }
    }
}
