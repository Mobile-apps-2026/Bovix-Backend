using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public static class AppointmentResourceFromEntityAssembler
{
    public static AppointmentResource ToResourceFromEntity(Appointment entity) =>
        new(entity.Id, entity.VeterinarianName, entity.ScheduledAt,
            entity.Lot, entity.Status, entity.Notes);
}
