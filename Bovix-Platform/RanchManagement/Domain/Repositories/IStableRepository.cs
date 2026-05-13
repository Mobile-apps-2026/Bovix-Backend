using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.RanchManagement.Domain.Repositories;

public interface IStableRepository : IBaseRepository<Stable>
{
    Task<Stable?> FindByNameAsync(string name);
}