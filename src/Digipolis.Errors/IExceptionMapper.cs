using System;

namespace Digipolis.Errors
{
    public interface IExceptionMapper
    {
        Error Resolve(Exception exception);
    }
}
