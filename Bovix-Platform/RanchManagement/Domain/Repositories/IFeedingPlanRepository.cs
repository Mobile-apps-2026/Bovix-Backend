using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.RanchManagement.Domain.Repositories;

public interface IFeedingPlanRepository : IBaseRepository<FeedingPlan>
{
    Task<FeedingPlan?> FindByLotAsync(string lot);
    Task<FeedingPlan?> FindByIdWithComponentsAsync(int id);
    Task<IEnumerable<FeedingPlan>> ListWithComponentsAsync();
    Task AddComponentAsync(FeedingComponent component);
}
