using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.RanchManagement.Domain.Repositories;

public interface IClinicalRecordRepository : IBaseRepository<ClinicalRecord>
{
    Task<IEnumerable<ClinicalRecord>> FindByBovineIdAsync(int bovineId);
}
