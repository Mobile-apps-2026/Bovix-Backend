using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IFeedingPlanQueryService
{
    Task<IEnumerable<FeedingPlan>> Handle(GetAllFeedingPlansQuery query);
    Task<FeedingPlan?> Handle(GetFeedingPlanByIdQuery query);
    Task<FeedingPlan?> Handle(GetFeedingPlanByLotQuery query);
}
