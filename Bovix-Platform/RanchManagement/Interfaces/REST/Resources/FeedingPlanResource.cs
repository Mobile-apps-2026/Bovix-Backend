namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record FeedingPlanResource(
    int Id,
    string Lot,
    decimal DailyRationKg,
    int AnimalCount,
    string? Notes,
    IEnumerable<FeedingComponentResource> Components);
