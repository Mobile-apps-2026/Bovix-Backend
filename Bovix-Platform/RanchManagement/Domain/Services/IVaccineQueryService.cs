using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IVaccineQueryService
{
    Task<IEnumerable<Vaccine>> Handle(GetAllVaccinesQuery query);
    
    Task<Vaccine> Handle(GetVaccinesByIdQuery query);
    
    Task<IEnumerable<Vaccine>> Handle(GetVaccinesByBovineIdQuery query);
}