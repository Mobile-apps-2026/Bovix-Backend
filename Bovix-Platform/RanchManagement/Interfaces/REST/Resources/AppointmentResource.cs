namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record AppointmentResource(
    int Id,
    string VeterinarianName,
    DateTime ScheduledAt,
    string? Lot,
    string Status,
    string? Notes);
