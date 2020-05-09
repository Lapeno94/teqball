using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Test.TeqBall.Host.Domain.Aggregates;
using Test.TeqBall.Host.Domain.Exceptions;
using Test.TeqBall.Host.Infrastructure.Repositories;
using Test.TeqBall.Interfaces.Api.Requests;
using Test.TeqBall.Interfaces.Api.Responses;

namespace Test.TeqBall.Host.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(ILogger<AppointmentService> logger, IAppointmentRepository appointmentRepository)
        {
            _logger = logger;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<CreateAppointmentResponse> Create(CreateAppointmentRequest request)
        {
            try
            {
                var appointment = new Appointment(request.Name, request.StartDateTime, request.Length, request.Owner, request.Invitee);

                var overlaps = await _appointmentRepository.QueryOverlaps(appointment);

                if (overlaps.Count() > 0)
                {
                    throw new AppoinmentOverlappedException($"{appointment.StartDateTime} and with {appointment.EndDateTime} is overlapped");
                }

                var entity = await _appointmentRepository.Save(appointment);

                return new CreateAppointmentResponse
                {
                    Id = entity.Id,
                    EndDateTime = entity.EndDateTime,
                    Invitee = entity.Invitee,
                    StartDateTime = entity.StartDateTime,
                    Length = entity.Length,
                    Name = entity.Name,
                    Owner = entity.Owner
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"{nameof(Create)} appoinment error occured", request);
                throw;
            }
        }

        public async Task<GetAllResponse> GetAll()
        {
            try
            {
                var result = new GetAllResponse();

                var entities = await _appointmentRepository.ListAll();

                if (entities.Any())
                {
                    foreach (var entity in entities)
                    {
                        result.Add(new CreateAppointmentResponse
                        {
                            Id = entity.Id,
                            EndDateTime = entity.EndDateTime,
                            Invitee = entity.Invitee,
                            StartDateTime = entity.StartDateTime,
                            Length = entity.Length,
                            Name = entity.Name,
                            Owner = entity.Owner
                        });
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"{nameof(GetAll)} appoinments error occured");
                throw;
            }
        }
    }
}
