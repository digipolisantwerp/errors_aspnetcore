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
            Assert.NotNull(error.Identifier);
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
            Assert.NotNull(error.ExtraParameters);
        }

        [Fact]
        private void MessagesIsInstantiatedByConstructor()
        {
            var error = new Error(extraParameters: null);
            Assert.NotNull(error.ExtraParameters);
        }

        [Fact]
        private void ErrorMessagesIsSet()
        {
            var errorMessage1 = new KeyValuePair<string, object>("key1", "message1");
            var errorMessage2 = new KeyValuePair<string, object>("key2", "message2");
            var errorMessages = new Dictionary<string, object>();
            errorMessages.AddRange(new []{ errorMessage1, errorMessage2 });

            var error = new Error(errorMessages);

            Assert.Equal(2, error.ExtraParameters.Count);
            Assert.Contains(errorMessage1, error.ExtraParameters);
            Assert.Contains(errorMessage2, error.ExtraParameters);
        }

        [Fact]
        private void ErrorMessagesNullInstantiatesEmptyMessageCollection()
        {
            var error = new Error(extraParameters: null);
            Assert.NotNull(error.ExtraParameters);
            Assert.Equal(0, error.ExtraParameters.Count);
        }

        [Fact]
        private void ErrorMessageIsSet()
        {
            var errorMessage1 = new KeyValuePair<string, object>("key1", "message1");
            var errorMessages = new Dictionary<string, object>();
            errorMessages.AddRange(new[] { errorMessage1 });


            var error = new Error(errorMessages);

            Assert.Equal(1, error.ExtraParameters.Count);
            Assert.Contains(errorMessage1, error.ExtraParameters);
        }
    }
}
