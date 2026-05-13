using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IStableQueryService
{
    Task<IEnumerable<Stable>> Handle(GetAllStablesQuery query);
    
    Task<Stable> Handle(GetStablesByIdQuery query);
}