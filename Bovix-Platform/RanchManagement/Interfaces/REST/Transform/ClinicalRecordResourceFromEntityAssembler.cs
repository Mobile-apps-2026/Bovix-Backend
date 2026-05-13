using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public static class ClinicalRecordResourceFromEntityAssembler
{
    public static ClinicalRecordResource ToResourceFromEntity(ClinicalRecord entity) =>
        new(entity.Id, entity.BovineId, entity.RecordDate,
            entity.Diagnosis, entity.Treatment, entity.Severity, entity.VeterinarianName);
}
