using System;

namespace Digipolis.Toolbox.Errors.Internal
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
        }

        internal class NotFoundException
        {
            internal const string Message = "Not found.";
        }

        internal class UnauthorizedException
        {
            internal const string Message = "Access denied.";
        }

        internal class ValidationException
        {
            internal const string Message = "Bad request.";
        }
    }
}
