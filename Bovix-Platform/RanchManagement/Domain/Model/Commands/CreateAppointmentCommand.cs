namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record CreateAppointmentCommand(
    string VeterinarianName,
    DateTime ScheduledAt,
    string? Lot,
    string? Status,
    string? Notes);
