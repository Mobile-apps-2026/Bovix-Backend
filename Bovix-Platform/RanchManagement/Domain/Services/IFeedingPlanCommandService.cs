using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IFeedingPlanCommandService
{
    Task<FeedingPlan?> Handle(CreateFeedingPlanCommand command);
    Task<FeedingPlan?> Handle(UpdateFeedingPlanCommand command);
    Task<FeedingPlan?> Handle(DeleteFeedingPlanCommand command);
    Task<FeedingComponent?> Handle(AddFeedingComponentCommand command);
}
