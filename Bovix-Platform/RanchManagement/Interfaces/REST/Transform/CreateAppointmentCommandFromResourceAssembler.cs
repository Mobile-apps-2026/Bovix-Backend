using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class CreateAppointmentCommandFromResourceAssembler
{
    public static CreateAppointmentCommand ToCommandFromResource(CreateAppointmentResource r) =>
        new(r.VeterinarianName, r.ScheduledAt, r.Lot, r.Status, r.Notes);
}
