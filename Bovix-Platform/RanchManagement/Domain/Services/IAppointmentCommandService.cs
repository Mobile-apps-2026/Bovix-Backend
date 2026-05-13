using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IAppointmentCommandService
{
    Task<Appointment?> Handle(CreateAppointmentCommand command);
    Task<Appointment?> Handle(UpdateAppointmentCommand command);
    Task<Appointment?> Handle(DeleteAppointmentCommand command);
}
