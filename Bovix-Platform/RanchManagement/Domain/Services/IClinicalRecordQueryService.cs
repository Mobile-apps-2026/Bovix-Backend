using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IClinicalRecordQueryService
{
    Task<IEnumerable<ClinicalRecord>> Handle(GetAllClinicalRecordsQuery query);
    Task<ClinicalRecord?> Handle(GetClinicalRecordByIdQuery query);
    Task<IEnumerable<ClinicalRecord>> Handle(GetClinicalRecordsByBovineIdQuery query);
}
