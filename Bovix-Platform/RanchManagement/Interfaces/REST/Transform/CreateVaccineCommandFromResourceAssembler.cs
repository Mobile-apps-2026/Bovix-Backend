using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class CreateVaccineCommandFromResourceAssembler
{
    public static CreateVaccineCommand ToCommandFromResource(CreateVaccineResource resource)
    {
        return new CreateVaccineCommand(
            resource.Name,
            resource.VaccineType,
            resource.VaccineDate,
            string.Empty,
            resource.BovineId,
            resource.fileData?.OpenReadStream() ?? null
        );
    }
}