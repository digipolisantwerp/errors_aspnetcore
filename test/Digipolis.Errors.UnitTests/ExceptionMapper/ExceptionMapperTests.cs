using System;
using System.Collections.Generic;
using System.Net;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;
using Xunit;

namespace Digipolis.Errors.UnitTests.ExceptionMapper
{
    public class ExceptionMapperTests
    {
        [Fact]
        private void DefaultMappingOnConstruction()
        {
            var mapper = new ExceptionMapperTester();
            Assert.NotNull(mapper.Resolve(new Exception()));
            Assert.NotNull(mapper.Resolve(new NotFoundException()));
            Assert.NotNull(mapper.Resolve(new UnauthorizedException()));
            Assert.NotNull(mapper.Resolve(new ValidationException()));
        }

        [Fact]
        private void RetrieveFrameworkMappedExceptionError()
        {
            var mapper = new ExceptionMapperTester();
            var error = mapper.Resolve(new NotFoundException());

            Assert.NotNull(error);
            Assert.Equal(Defaults.NotFoundException.Title, error.Title);
            Assert.Equal(Defaults.NotFoundException.Code, error.Code);
            Assert.Equal(404, error.Status);
        }

        [Fact]
        private void RetrieveMappedExceptionError()
        {
            var mapper = new ExceptionMapperTester();
            var error = mapper.Resolve(new NotImplementedException());

            Assert.NotNull(error);
            Assert.Equal("Methode call not allowed", error.Title);
            Assert.Equal("NOTF001", error.Code);
            Assert.Equal(404, error.Status);
        }

        [Fact]
        private void RetrieveUnMappedExceptionError()
        {
            var mapper = new ExceptionMapperTester();
            var error = mapper.Resolve(new AggregateException());

            Assert.NotNull(error);
            Assert.Equal("We are currently experiencing a technical error", error.Title);
            Assert.Equal("TECHE001", error.Code);
            Assert.Equal(500, error.Status);
        }

        [Fact]
        private void RetrieveMappedExceptionErrorByStatusCode()
        {
            var mapper = new ExceptionMapperTester();
            var error = mapper.Resolve(new UnauthorizedAccessException());

            Assert.NotNull(error);
            Assert.Null(error.Title);
            Assert.Null(error.Code);
            Assert.Equal(403, error.Status);
        }

        [Fact]
        private void ResolveEmptyExceptionReturnsDefaultError()
        {
            var mapper = new ExceptionMapperTester();
            var error = mapper.Resolve(null);

            Assert.NotNull(error);
            Assert.Equal("We are currently experiencing a technical error", error.Title);
            Assert.Equal("TECHE001", error.Code);
            Assert.Equal(500, error.Status);
        }
    }
}
