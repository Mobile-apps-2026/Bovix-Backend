using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.RanchManagement.Domain.Services;

namespace Bovix_Platform.RanchManagement.Application.Internal.QueryServices;

public class AppointmentQueryService(IAppointmentRepository repository) : IAppointmentQueryService
{
    public async Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsQuery query) =>
        await repository.ListAsync();

    public async Task<Appointment?> Handle(GetAppointmentByIdQuery query) =>
        await repository.FindByIdAsync(query.Id);

    public async Task<Appointment?> Handle(GetNextAppointmentQuery query) =>
        await repository.FindNextAsync();
}
