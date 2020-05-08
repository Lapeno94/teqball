using System.Collections.Generic;
using System.Threading.Tasks;
using Test.TeqBall.Host.Domain.Aggregates;

namespace Test.TeqBall.Host.Infrastructure.Repositories
{
    public interface IAppointmentRepository : IRespository
    {
        Task<Appointment> Save(Appointment appointment);

        Task<IEnumerable<Appointment>> QueryOverlaps(Appointment appointment);

        Task<IEnumerable<Appointment>> ListAll();
    }
}