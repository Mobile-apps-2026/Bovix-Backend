namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record CreateAppointmentResource(
    string VeterinarianName,
    DateTime ScheduledAt,
    string? Lot,
    string? Status,
    string? Notes);
