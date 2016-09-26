using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digipolis.Errors
{
    public interface IExceptionMapper
    {
        Error Resolve(Exception exception);
    }
}
