using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IAppointmentQueryService
{
    Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsQuery query);
    Task<Appointment?> Handle(GetAppointmentByIdQuery query);
    Task<Appointment?> Handle(GetNextAppointmentQuery query);
}
