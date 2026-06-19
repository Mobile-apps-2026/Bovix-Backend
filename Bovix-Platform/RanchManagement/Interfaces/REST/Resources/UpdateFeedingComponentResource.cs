namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record UpdateFeedingComponentResource(
    string Name,
    int Percentage,
    decimal AmountKg);
