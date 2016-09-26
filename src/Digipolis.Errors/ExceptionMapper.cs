using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Digipolis.Errors.Exceptions;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors
{
    public abstract class ExceptionMapper : IExceptionMapper
    {
        private static ConcurrentDictionary<Type, Action<Error, Exception>> _errorMappings;

        protected ExceptionMapper()
        {
            _errorMappings = new ConcurrentDictionary<Type, Action<Error, Exception>>();
            CreateMap<Exception>(CreateDefaultMap);
            CreateMap<NotFoundException>(CreateNotFoundMap);
            CreateMap<UnauthorizedException>(CreateUnauthorizedMap);
            CreateMap<ValidationException>(CreateValidationMap);
            Configure();
        }

        public abstract void Configure();

        public abstract void CreateDefaultMap(Error error, Exception exception);

        public virtual void CreateNotFoundMap(Error error, NotFoundException exception)
        {
            error.Title = Defaults.NotFoundException.Title;
            error.Code = Defaults.NotFoundException.Code;
            error.Status = (int) HttpStatusCode.NotFound;
            error.ExtraParameters = exception.Messages.ToDictionary(ms => ms.Key, ms => (object)ms.Value);
        }

        public virtual void CreateUnauthorizedMap(Error error, UnauthorizedException exception)
        {
            error.Title = Defaults.UnauthorizedException.Title;
            error.Code = Defaults.UnauthorizedException.Code;
            error.Status = (int)HttpStatusCode.Forbidden;
            error.ExtraParameters = exception.Messages.ToDictionary(ms => ms.Key, ms => (object)ms.Value);
        }

        public virtual void CreateValidationMap(Error error, ValidationException exception)
        {
            error.Title = Defaults.ValidationException.Title;
            error.Code = Defaults.ValidationException.Code;
            error.Status = (int)HttpStatusCode.BadRequest;
            error.ExtraParameters = exception.Messages.ToDictionary(ms => ms.Key, ms => (object)ms.Value);
        }

        public void CreateMap<TException>(Action<Error, TException> configError) where TException : Exception
        {
            Action<Error, Exception> action = (x, y) => configError(x, (TException)y);
            _errorMappings.TryAdd(typeof(TException), action);
        }

        protected Error Map(Exception exception)
        {
            var type = exception.GetType();
            var error = new Error();

            if (_errorMappings.ContainsKey(type))
                _errorMappings[type](error, exception);
            else if (_errorMappings.ContainsKey(typeof(Exception)))
                _errorMappings[typeof(Exception)](error, exception);
            else
                error = null;

            return error;
        }

        public virtual Error Resolve(Exception exception)
        {
            var error = Map(exception);

            var validationException = exception as ValidationException;
            if (validationException != null)
                error.ExtraParameters = validationException.Messages.ToDictionary(x => x.Key, x => (object)x.Value);

            return error;
        }
    }
}
