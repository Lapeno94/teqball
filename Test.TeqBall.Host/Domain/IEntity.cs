using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.TeqBall.Host.Domain
{
    interface IEntity
    {
        string Id { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
