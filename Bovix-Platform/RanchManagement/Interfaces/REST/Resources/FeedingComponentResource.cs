namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record FeedingComponentResource(
    int Id,
    string Name,
    int Percentage,
    decimal AmountKg);
