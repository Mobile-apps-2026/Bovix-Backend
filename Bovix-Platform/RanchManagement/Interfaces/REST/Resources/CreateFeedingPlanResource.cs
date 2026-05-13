namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record CreateFeedingPlanResource(
    string Lot,
    decimal DailyRationKg,
    int AnimalCount,
    string? Notes);
