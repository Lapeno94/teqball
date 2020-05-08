using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.TeqBall.Host.Domain.Aggregates
{
    public class Appointment : IAggregateRoot, IEntity
    {
        public string Name { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Owner{ get; set; }

        public IEnumerable<string> Invitee { get; set; }
    }
}
