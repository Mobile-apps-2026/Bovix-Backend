using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.RanchManagement.Domain.Services;

namespace Bovix_Platform.RanchManagement.Application.Internal.QueryServices;

public class ClinicalRecordQueryService(IClinicalRecordRepository repository) : IClinicalRecordQueryService
{
    public async Task<IEnumerable<ClinicalRecord>> Handle(GetAllClinicalRecordsQuery query) =>
        await repository.ListAsync();

    public async Task<ClinicalRecord?> Handle(GetClinicalRecordByIdQuery query) =>
        await repository.FindByIdAsync(query.Id);

    public async Task<IEnumerable<ClinicalRecord>> Handle(GetClinicalRecordsByBovineIdQuery query) =>
        await repository.FindByBovineIdAsync(query.BovineId);
}
