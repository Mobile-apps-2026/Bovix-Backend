using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class UpdateClinicalRecordCommandFromResourceAssembler
{
    public static UpdateClinicalRecordCommand ToCommandFromResource(int id, UpdateClinicalRecordResource r) =>
        new(id, r.BovineId, r.RecordDate, r.Diagnosis, r.Treatment, r.Severity, r.VeterinarianName);
}
