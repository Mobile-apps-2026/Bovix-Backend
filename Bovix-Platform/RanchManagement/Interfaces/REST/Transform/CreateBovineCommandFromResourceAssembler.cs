using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class CreateBovineCommandFromResourceAssembler
{
    public static CreateBovineCommand ToCommandFromResource(CreateBovineResource resource)
    {
        return new CreateBovineCommand(
            resource.Name,
            resource.Gender,
            resource.BirthDate,
            resource.Breed,
            resource.Location,
            resource.Lot,
            resource.Status,
            resource.WeightKg,
            string.Empty,
            resource.StableId,
            resource.fileData?.OpenReadStream() ?? null
        );
    }
}
