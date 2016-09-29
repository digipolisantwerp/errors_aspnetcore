using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors.UnitTests.ExceptionMapper
{
    public class ExceptionMapperTester :  Errors.ExceptionMapper
    {
        protected override void Configure()
        {
            CreateMap<NotImplementedException>((error, ex) =>
            {
                error.Status = 404;
                error.Title = "Methode call not allowed";
                error.Code = "NOTF001";
            });

            CreateMap<UnauthorizedAccessException>(403);
        }

        protected override void CreateDefaultMap(Error error, Exception exception)
        {
            error.Status = 500;
            error.Title = "We are currently experiencing a technical error";
            error.Code = "TECHE001";
        }

        protected override void CreateNotFoundMap(Error error, NotFoundException exception)
        {
            error.Title = Defaults.NotFoundException.Title;
            error.Code = Defaults.NotFoundException.Code;
            error.Status = 404;
            error.ExtraParameters = exception.Messages.ToDictionary(ms => ms.Key, ms => (object)ms.Value);
        }

        protected override void CreateUnauthorizedMap(Error error, UnauthorizedException exception)
        {
        }

        protected override void CreateValidationMap(Error error, ValidationException exception)
        {
            error.Title = Defaults.ValidationException.Title;
            error.Code = Defaults.ValidationException.Code;
            error.Status = 400;
            error.ExtraParameters = exception.Messages.ToDictionary(ms => ms.Key, ms => (object)ms.Value);
        }
    }
}
