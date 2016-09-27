using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digipolis.Errors.UnitTests.ExceptionMapper
{
    public class ExceptionMapperTester :  Errors.ExceptionMapper
    {
        public override void Configure()
        {
            CreateMap<NotImplementedException>((error, ex) =>
            {
                
            });
        }

        public override void CreateDefaultMap(Error error, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
