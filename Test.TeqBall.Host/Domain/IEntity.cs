using System;

namespace Test.TeqBall.Host.Domain
{
    interface IEntity
    {
        string Id { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
