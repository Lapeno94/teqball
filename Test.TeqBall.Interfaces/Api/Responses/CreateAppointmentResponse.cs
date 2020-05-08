using System;
using System.Collections.Generic;
using System.Text;

namespace Test.TeqBall.Interfaces.Api.Responses
{
    public class CreateAppointmentResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Owner { get; set; }

        public IEnumerable<string> Invitee { get; set; }
    }
}
