using System;
using Toolbox.Errors.Internal;

namespace Toolbox.Errors.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException()
        { }

        public BaseException(string message) : base(message)
        {
            CreateDefaultError(message);
        }

        public BaseException(string message, Exception innerException) : base(message, innerException)
        {
            CreateDefaultError(message);
        }

        public BaseException(Error error, string message = null, Exception innerException = null) : base(message, innerException)
        {
            Error = error;
        }
        
        public int HttpStatusCode { get; set; } = Defaults.BaseException.HttpStatusCode;
        public Error Error { get; set; }

        protected void CreateDefaultError(string message)
        {
            Error = new Error(Guid.NewGuid().ToString(), new ErrorMessage[] { new DefaultErrorMessage(message) });
        }
    }
}
