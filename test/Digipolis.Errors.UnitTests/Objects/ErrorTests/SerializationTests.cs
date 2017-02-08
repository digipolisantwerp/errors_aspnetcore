using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Digipolis.Errors.UnitTests.Objects.ErrorTests
{
    public class SerializationTests
    {
        [Fact]
        public void CanBeSerialized()
        {
            //Act
            var error = new Error
            {
                Code = "001",
                Status = 400,
                Title = "Title",
                Type = new Uri("http://moreinfo.com"),
                ExtraParameters = new Dictionary<string, IEnumerable<string>> { { "key1", new string[] { "value1" } }, { "key2", new string[] { "value2" } } }
            };

            //Arrange
            var serialized = JsonConvert.SerializeObject(error);

            //Assert by no exception
            
        }

        [Fact]
        public void CanBeDeserialized()
        {
            //Act
            var serialized = "{\"Identifier\":\"a931740d-733d-4549-a0a3-65e48eda9d9b\",\"Type\":\"http://moreinfo.com\",\"Title\":\"Title\",\"Status\":400,\"Code\":\"001\",\"ExtraParameters\":{\"key1\":[\"value1\"],\"key2\":[\"value2\"]}}";

            //Arrange
            var error = JsonConvert.DeserializeObject<Error>(serialized);

            Assert.NotNull(error);
            Assert.Equal("001", error.Code);
            Assert.Equal(400, error.Status);
            Assert.Equal("Title", error.Title);
            Assert.Equal("a931740d-733d-4549-a0a3-65e48eda9d9b", error.Identifier.ToString());
            Assert.Contains(error.ExtraParameters, kvp => kvp.Key == "key1" && kvp.Value.Contains("value1"));
            Assert.Contains(error.ExtraParameters, kvp => kvp.Key == "key2" && kvp.Value.Contains("value2"));
        }
    }
}
