using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.TeqBall.Host.Domain.Aggregates;

namespace Test.TeqBall.Host.Infrastructure.Repositories
{
    public class MongoDbRepository : IAppointmentRepository
    {
        private readonly IMongoCollection<Appointment> _collection;
        private readonly ILogger<MongoDbRepository> _logger;

        public MongoDbRepository(ILogger<MongoDbRepository> logger, IOptions<ConnectionOptions> options)
        {
            var client = new MongoClient(options.Value.MongoDbCluster);
            var database = client.GetDatabase(options.Value.MongoDatabase);

            _collection = database.GetCollection<Appointment>("appointment");
            _logger = logger;
        }

        public async Task<Appointment> Save(Appointment appointment)
        {
            try
            {
                await _collection.InsertOneAsync(appointment);
                return appointment;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Database Error Occured", appointment);
                throw;
            }
        }

        public async Task<IEnumerable<Appointment>> QueryOverlaps(Appointment appointment)
        {
            try
            {
                var filter = Builders<Appointment>.Filter.And(Builders<Appointment>.Filter.Lt("StartDateTime", appointment.StartDateTime), Builders<Appointment>.Filter.Gt("EndDateTime", appointment.EndDateTime));
                var appointments = await _collection.Find(filter).ToListAsync();
                return appointments;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Database Error Occured", appointment);
                throw;
            }
        }

        public async Task<IEnumerable<Appointment>> ListAll()
        {
            try
            {
                var appointments = await _collection.Find(_ => true).ToListAsync();
                return appointments;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Database Error Occured");
                throw;
            }
        }
    }
}
