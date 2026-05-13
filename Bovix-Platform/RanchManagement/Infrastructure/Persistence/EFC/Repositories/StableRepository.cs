using Microsoft.EntityFrameworkCore;
using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Bovix_Platform.RanchManagement.Infrastructure.Persistence.EFC.Repositories;

public class StableRepository(AppDbContext ctx)
    : BaseRepository<Stable>(ctx), IStableRepository
{
    public async Task<Stable?> FindByNameAsync(string name)
    {
        return await Context.Set<Stable>().FirstOrDefaultAsync(f=>f.Name == name);
    }
}