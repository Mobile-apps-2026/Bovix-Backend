namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record CreateFeedingPlanCommand(
    string Lot,
    decimal DailyRationKg,
    int AnimalCount,
    string? Notes);
