using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.RanchManagement.Domain.Services;

namespace Bovix_Platform.RanchManagement.Application.Internal.QueryServices;

public class FeedingPlanQueryService(IFeedingPlanRepository repository) : IFeedingPlanQueryService
{
    public async Task<IEnumerable<FeedingPlan>> Handle(GetAllFeedingPlansQuery query) =>
        await repository.ListWithComponentsAsync();

    public async Task<FeedingPlan?> Handle(GetFeedingPlanByIdQuery query) =>
        await repository.FindByIdWithComponentsAsync(query.Id);

    public async Task<FeedingPlan?> Handle(GetFeedingPlanByLotQuery query) =>
        await repository.FindByLotAsync(query.Lot);
}
