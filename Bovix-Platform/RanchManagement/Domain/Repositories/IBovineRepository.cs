using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.RanchManagement.Domain.Repositories;

public interface IBovineRepository : IBaseRepository<Bovine>
{
    Task<Bovine?> FindByNameAsync(string name);
    
    Task<IEnumerable<Bovine>> FindByStableIdAsync(int? stableId);
    
    Task<int> CountBovinesByStableIdAsync(int stableId);
}