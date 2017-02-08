using System;
using System.Collections.Generic;
using NuGet.Packaging;
using Xunit;

namespace Digipolis.Errors.UnitTests.Objects.ErrorTests
{
    public class ToStringTests
    {
        [Fact]
        private void ToStringContainsId()
        {
            var id = Guid.NewGuid();
            var error = new Error(id);
            Assert.Contains(id.ToString(), error.ToString());
        }

        [Fact]
        private void ToStringContainsMessagesCollection()
        {
            var id = Guid.NewGuid();
            var errorMessage1 = new string[] { "message1" };
            var errorMessage2 = new string[] { "message2" };
            var messages = new Dictionary<string, IEnumerable<string>> { { "key1", errorMessage1 }, { "key2", errorMessage2 } };
            var error = new Error(id, messages);

            Assert.Contains("message1", error.ToString());
            Assert.Contains("message2", error.ToString());
        }

        [Fact]
        private void ToStringContainsMessagesCollections()
        {
            var id = Guid.NewGuid();
            var errorMessage1 = new string[] { "message1" };
            var errorMessage2 = new string[] { "message2" };
            var messages = new Dictionary<string, IEnumerable<string>> { { "key1", errorMessage1 }, { "key2", errorMessage2 } };
            var error = new Error(id, messages);

            Assert.Contains("message1", error.ToString());
            Assert.Contains("message2", error.ToString());
        }
    }
}
