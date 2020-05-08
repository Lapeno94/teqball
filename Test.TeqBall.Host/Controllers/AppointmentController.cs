using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.TeqBall.Host.Application.Services;
using Test.TeqBall.Interfaces.Api.Requests;
using Test.TeqBall.Interfaces.Api.Responses;

namespace Test.TeqBall.Host.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentService appointmentService)
        {
            _logger = logger;
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<GetAllResponse> GetAll()
        {
            return await _appointmentService.GetAll();
        }

        [HttpPost]
        public async Task<CreateAppointmentResponse> Create(CreateAppointmentRequest request)
        {
            return await _appointmentService.Create(request);
        }
    }
}
