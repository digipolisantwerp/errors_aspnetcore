using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Toolbox.Errors.UnitTests.Objects.ErrorTests
{
    public class AddErrorMessagesTests
    {
        [Fact]
        private void ErrorMessageCollectionIsAddedToMessagesCollection()
        {
            var errorMessage1 = new ErrorMessage("key1", "message1");
            var errorMessage2 = new ErrorMessage("key2", "message2");
            var errorMessages = new ErrorMessage[] { errorMessage1, errorMessage2 };

            var error = new Error("id");
            error.AddErrorMessages(errorMessages);

            Assert.Equal(2, error.Messages.Count());
            Assert.Contains(errorMessage1, error.Messages);
            Assert.Contains(errorMessage2, error.Messages);
        }

        [Fact]
        private void NullErrorMessageCollectionAddsNothingToMessagesCollection()
        {
            var error = new Error("id");

            IEnumerable<ErrorMessage> nullErrorMessages = null;
            error.AddErrorMessages(nullErrorMessages);

            Assert.Equal(0, error.Messages.Count());
        }

        [Fact]
        private void NullErrorMessagesInCollectionAreNotAddedToMessagesCollection()
        {
            var errorMessage1 = new ErrorMessage("key", "message");
            var errorMessages = new ErrorMessage[] { errorMessage1, null };

            var error = new Error("id");
            error.AddErrorMessages(errorMessages);

            Assert.Equal(1, error.Messages.Count());
            Assert.Contains(errorMessage1, error.Messages);
        }
    }
}
