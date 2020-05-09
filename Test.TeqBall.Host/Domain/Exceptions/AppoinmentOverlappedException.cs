using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.TeqBall.Host.Domain.Exceptions
{
    public class AppoinmentOverlappedException : Exception
    {
        public AppoinmentOverlappedException(string message) : base(message)
        {
        }
    }
}
