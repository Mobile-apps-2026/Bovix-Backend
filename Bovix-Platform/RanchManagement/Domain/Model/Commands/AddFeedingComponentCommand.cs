namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record AddFeedingComponentCommand(
    int FeedingPlanId,
    string Name,
    int Percentage,
    decimal AmountKg);
