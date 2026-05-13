using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class UpdateAppointmentCommandFromResourceAssembler
{
    public static UpdateAppointmentCommand ToCommandFromResource(int id, UpdateAppointmentResource r) =>
        new(id, r.VeterinarianName, r.ScheduledAt, r.Lot, r.Status, r.Notes);
}
