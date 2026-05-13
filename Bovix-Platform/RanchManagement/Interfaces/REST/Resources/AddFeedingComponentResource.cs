namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record AddFeedingComponentResource(
    string Name,
    int Percentage,
    decimal AmountKg);
