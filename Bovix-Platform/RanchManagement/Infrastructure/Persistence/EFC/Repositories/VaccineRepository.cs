using Microsoft.EntityFrameworkCore;
using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Bovix_Platform.RanchManagement.Infrastructure.Persistence.EFC.Repositories;

public class VaccineRepository(AppDbContext ctx)
    : BaseRepository<Vaccine>(ctx), IVaccineRepository
{
    public async Task<Vaccine?> FindByNameAsync(string name)
    {
        return await Context.Set<Vaccine>().FirstOrDefaultAsync(f => f.Name == name);
    }
    
    public async Task<IEnumerable<Vaccine>> FindByBovineIdAsync(int? bovineId)
    {
        return await Context.Set<Vaccine>().Where(f => f.BovineId == bovineId).ToListAsync();
    }
}