using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class CreateClinicalRecordCommandFromResourceAssembler
{
    public static CreateClinicalRecordCommand ToCommandFromResource(CreateClinicalRecordResource r) =>
        new(r.BovineId, r.RecordDate, r.Diagnosis, r.Treatment, r.Severity, r.VeterinarianName);
}
