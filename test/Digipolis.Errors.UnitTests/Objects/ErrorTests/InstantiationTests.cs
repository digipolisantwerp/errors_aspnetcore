using System;
using System.Linq;
using Xunit;

namespace Digipolis.Errors.UnitTests.Objects.ErrorTests
{
    public class InstantiationTests
    {
        [Fact]
        private void IdIsDefaulted()
        {
            var error = new Error();
            Assert.NotNull(error.Id);
            Assert.NotEmpty(error.Id);
        }

        [Fact]
        private void IdIsSet()
        {
            var error = new Error("12345");
            Assert.Equal("12345", error.Id);
        }

        [Fact]
        private void IdNullRaisesArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Error(null));
            Assert.Equal("id", ex.ParamName);
        }

        [Fact]
        private void IdEmptyRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Error(""));
            Assert.Equal("id", ex.ParamName);
        }

        [Fact]
        private void IdWhiteSpaceRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Error("  "));
            Assert.Equal("id", ex.ParamName);
        }

        [Fact]
        private void MessagesIsInstantiated()
        {
            var error = new Error("id");
            Assert.NotNull(error.Messages);
        }

        [Fact]
        private void ErrorMessagesIsSet()
        {
            var errorMessage1 = new ErrorMessage("key1", "message1");
            var errorMessage2 = new ErrorMessage("key2", "message2");
            var errorMessages = new ErrorMessage[] { errorMessage1, errorMessage2 };

            var error = new Error("id", errorMessages: errorMessages);

            Assert.Equal(2, error.Messages.Count());
            Assert.Contains(errorMessage1, error.Messages);
            Assert.Contains(errorMessage2, error.Messages);
        }

        [Fact]
        private void ErrorMessagesNullInstantiatesEmptyMessageCollection()
        {
            var error = new Error("id", errorMessages: null);
            Assert.NotNull(error.Messages);
            Assert.Equal(0, error.Messages.Count());
        }

        [Fact]
        private void ErrorMessageIsSet()
        {
            var errorMessage1 = new ErrorMessage("key1", "message1");

            var error = new Error("id", errorMessage1);

            Assert.Equal(1, error.Messages.Count());
            Assert.Contains(errorMessage1, error.Messages);
        }
    }
}
