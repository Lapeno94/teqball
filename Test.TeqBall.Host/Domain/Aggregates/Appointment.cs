using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.TeqBall.Host.Domain.Aggregates
{
    public class Appointment : IAggregateRoot, IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int Length { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Owner { get; set; }

        public IEnumerable<string> Invitee { get; set; }

        public Appointment(string name, DateTime startDateTime, int lengthInMinutes, string owner, IEnumerable<string> invitee)
        {
            Name = name;
            StartDateTime = startDateTime;
            Length = lengthInMinutes;
            Owner = owner;
            Invitee = invitee;
            EndDateTime = startDateTime.AddMinutes(lengthInMinutes);
        }
    }
}
