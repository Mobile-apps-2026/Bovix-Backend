using Microsoft.EntityFrameworkCore;
using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Bovix_Platform.RanchManagement.Infrastructure.Persistence.EFC.Repositories;

public class ClinicalRecordRepository(AppDbContext ctx)
    : BaseRepository<ClinicalRecord>(ctx), IClinicalRecordRepository
{
    public async Task<IEnumerable<ClinicalRecord>> FindByBovineIdAsync(int bovineId)
    {
        return await Context.Set<ClinicalRecord>()
            .Where(r => r.BovineId == bovineId)
            .OrderByDescending(r => r.RecordDate)
            .ToListAsync();
    }
}
