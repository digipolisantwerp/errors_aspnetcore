using System;
using System.Linq;
using Xunit;

namespace Digipolis.Toolbox.Errors.UnitTests.Objects.ErrorTests
{
    public class AddErrorMessageTests
    {
        [Fact]
        private void ErrorMessageIsAddedToCollection()
        {
            var error = new Error("id");
            var errorMessage = new ErrorMessage("aKey", "aMessage");

            error.AddErrorMessage(errorMessage);

            Assert.Contains(errorMessage, error.Messages);
        }

        [Fact]
        private void ErrorMessageNullDoesNotAddToCollection()
        {
            var error = new Error("id");
            Assert.Equal(0, error.Messages.Count());

            ErrorMessage nullErrorMessage = null;
            error.AddErrorMessage(nullErrorMessage);

            Assert.Equal(0, error.Messages.Count());
        }
    }
}
