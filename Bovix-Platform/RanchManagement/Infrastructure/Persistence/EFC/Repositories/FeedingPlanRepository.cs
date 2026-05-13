using Microsoft.EntityFrameworkCore;
using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Bovix_Platform.RanchManagement.Infrastructure.Persistence.EFC.Repositories;

public class FeedingPlanRepository(AppDbContext ctx)
    : BaseRepository<FeedingPlan>(ctx), IFeedingPlanRepository
{
    public async Task<FeedingPlan?> FindByLotAsync(string lot)
    {
        return await Context.Set<FeedingPlan>()
            .Include(p => p.Components)
            .FirstOrDefaultAsync(p => p.Lot == lot);
    }

    public async Task<FeedingPlan?> FindByIdWithComponentsAsync(int id)
    {
        return await Context.Set<FeedingPlan>()
            .Include(p => p.Components)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<FeedingPlan>> ListWithComponentsAsync()
    {
        return await Context.Set<FeedingPlan>()
            .Include(p => p.Components)
            .ToListAsync();
    }

    public async Task AddComponentAsync(FeedingComponent component)
    {
        await Context.Set<FeedingComponent>().AddAsync(component);
    }
}
