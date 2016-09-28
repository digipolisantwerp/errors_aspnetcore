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
                error.Status = (int) HttpStatusCode.NotFound;
                error.Title = "Methode call not allowed";
                error.Code = "NOTF001";
            });

            CreateMap<UnauthorizedAccessException>((int)HttpStatusCode.Forbidden);
        }

        protected override void CreateDefaultMap(Error error, Exception exception)
        {
            error.Status = (int) HttpStatusCode.InternalServerError;
            error.Title = "We are currently experiencing a technical error";
            error.Code = "TECHE001";
        }

        protected override void CreateNotFoundMap(Error error, NotFoundException exception)
        {
            error.Title = Defaults.NotFoundException.Title;
            error.Code = Defaults.NotFoundException.Code;
            error.Status = (int)HttpStatusCode.NotFound;
            error.ExtraParameters = exception.Messages.ToDictionary(ms => ms.Key, ms => (object)ms.Value);
        }

        protected override void CreateUnauthorizedMap(Error error, UnauthorizedException exception)
        {
        }

        protected override void CreateValidationMap(Error error, ValidationException exception)
        {
            error.Title = Defaults.ValidationException.Title;
            error.Code = Defaults.ValidationException.Code;
            error.Status = (int)HttpStatusCode.BadRequest;
            error.ExtraParameters = exception.Messages.ToDictionary(ms => ms.Key, ms => (object)ms.Value);
        }
    }
}
