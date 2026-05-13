namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record UpdateAppointmentCommand(
    int Id,
    string VeterinarianName,
    DateTime ScheduledAt,
    string? Lot,
    string? Status,
    string? Notes);
