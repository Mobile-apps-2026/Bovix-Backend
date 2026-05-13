namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record UpdateFeedingPlanCommand(
    int Id,
    string Lot,
    decimal DailyRationKg,
    int AnimalCount,
    string? Notes);
