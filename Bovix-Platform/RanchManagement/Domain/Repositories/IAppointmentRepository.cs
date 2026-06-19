using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.RanchManagement.Domain.Repositories;

public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    Task<Appointment?> FindNextAsync();

    Task<IEnumerable<Appointment>> FindByUserIdAsync(int userId);

    Task<Appointment?> FindNextByUserIdAsync(int userId);
}
