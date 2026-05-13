using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IBovineQueryService
{
    Task<IEnumerable<Bovine>> Handle(GetAllBovinesQuery query);
    
    Task<Bovine> Handle(GetBovinesByIdQuery query);
    
    Task<IEnumerable<Bovine>> Handle(GetBovinesByStableIdQuery query);
}