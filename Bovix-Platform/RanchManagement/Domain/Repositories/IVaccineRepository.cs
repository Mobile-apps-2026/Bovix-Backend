using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.RanchManagement.Domain.Repositories;

public interface IVaccineRepository : IBaseRepository<Vaccine>
{
    Task<Vaccine?> FindByNameAsync(string name);
    
    Task<IEnumerable<Vaccine>> FindByBovineIdAsync(int? bovineId);
}