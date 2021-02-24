using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Packaging;
using Xunit;

namespace Digipolis.Errors.UnitTests.Objects.ErrorTests
{
    public class InstantiationTests
    {
        [Fact]
        private void IdIsDefaulted()
        {
            var error = new Error();
            Assert.NotEqual(Guid.Empty, error.Identifier);
        }

        [Fact]
        private void IdIsSet()
        {
            var id = Guid.NewGuid();
            var error = new Error(id);
            Assert.Equal(id, error.Identifier);
        }

        [Fact]
        private void IdEmptyRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Error(Guid.Empty));
            Assert.Equal("identifier", ex.ParamName);
        }

        [Fact]
        private void MessagesIsInstantiated()
        {
            var error = new Error();
            Assert.NotNull(error.ExtraInfo);
        }

        [Fact]
        private void MessagesIsInstantiatedByConstructor()
        {
            var error = new Error(extraInfo: null);
            Assert.NotNull(error.ExtraInfo);
        }

        [Fact]
        private void ErrorMessagesIsSet()
        {
            var errorMessage1 = new KeyValuePair<string, IEnumerable<string>>("key1", new string[] { "message1" });
            var errorMessage2 = new KeyValuePair<string, IEnumerable<string>>("key2", new string[] { "message2" });
            var errorMessages = new Dictionary<string, IEnumerable<string>>();
            errorMessages.AddRange(new []{ errorMessage1, errorMessage2 });

            var error = new Error(errorMessages);

            Assert.Equal(2, error.ExtraInfo.Count);
            Assert.Contains(errorMessage1, error.ExtraInfo);
            Assert.Contains(errorMessage2, error.ExtraInfo);
        }

        [Fact]
        private void ErrorMessagesNullInstantiatesEmptyMessageCollection()
        {
            var error = new Error(extraInfo: null);
            Assert.NotNull(error.ExtraInfo);
            Assert.Empty(error.ExtraInfo);
        }

        [Fact]
        private void ErrorMessageIsSet()
        {
            var errorMessage1 = new KeyValuePair<string, IEnumerable<string>>("key1", new string[] { "message1" });
            var errorMessages = new Dictionary<string, IEnumerable<string>>();
            errorMessages.AddRange(new[] { errorMessage1 });


            var error = new Error(errorMessages);

            Assert.Single(error.ExtraInfo);
            Assert.Contains(errorMessage1, error.ExtraInfo);
        }
    }
}
