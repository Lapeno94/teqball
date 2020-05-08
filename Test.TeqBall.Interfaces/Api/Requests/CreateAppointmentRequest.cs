using System;
using System.Collections.Generic;
using System.Text;

namespace Test.TeqBall.Interfaces.Api.Requests
{
    public class CreateAppointmentRequest
    {
        public string Name { get; set; }

        public DateTime StartDateTime { get; set; }

        public int Length { get; set; }

        public string Owner { get; set; }

        public IEnumerable<string> Invitee { get; set; }
    }
}
