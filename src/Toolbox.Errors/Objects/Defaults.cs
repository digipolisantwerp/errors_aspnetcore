using System;

namespace Toolbox.Errors.Internal
{
    internal class Defaults
    {
        internal class ErrorMessage
        {
            internal const string Key = "";
            internal const string NullString = "null";
        }

        internal class BaseException
        {
            internal const int HttpStatusCode = 500;
        }

        internal class NotFoundException
        {
            internal const int HttpStatusCode = 404;
            internal const string Message = "Not found.";
        }

        internal class UnauthorizedException
        {
            internal const int HttpStatusCode = 401;
            internal const string Message = "Access denied.";
        }

        internal class ValidationException
        {
            internal const int HttpStatusCode = 400;
            internal const string Message = "Bad request.";
        }
    }
}
