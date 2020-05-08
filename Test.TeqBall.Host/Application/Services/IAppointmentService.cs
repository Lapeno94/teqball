using System.Threading.Tasks;
using Test.TeqBall.Interfaces.Api.Requests;
using Test.TeqBall.Interfaces.Api.Responses;

namespace Test.TeqBall.Host.Application.Services
{
    public interface IAppointmentService
    {
        Task<CreateAppointmentResponse> Create(CreateAppointmentRequest request);

        Task<GetAllResponse> GetAll();

    }
}
