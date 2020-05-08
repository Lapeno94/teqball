using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.TeqBall.Host.Domain
{
    interface IAggregateRoot
    {
        string Name { get; set; }

        string Owner { get; set; }

        int Length { get; set; }

        IEnumerable<string> Invitee { get; set; }
    }
}
