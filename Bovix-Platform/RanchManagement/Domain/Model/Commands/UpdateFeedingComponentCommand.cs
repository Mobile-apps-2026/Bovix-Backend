namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record UpdateFeedingComponentCommand(int Id, int FeedingPlanId, string Name, int Percentage, decimal AmountKg);
