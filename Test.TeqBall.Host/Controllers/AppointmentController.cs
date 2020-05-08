using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Test.TeqBall.Host.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(ILogger<AppointmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> GetAll()
        {
            return await Task.FromResult("asd");
        }

        [HttpGet]
        public async Task<string> Create()
        {
            return await Task.FromResult("asd");
        }
    }
}
