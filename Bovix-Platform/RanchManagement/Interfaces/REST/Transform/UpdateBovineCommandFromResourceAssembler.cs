using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class UpdateBovineCommandFromResourceAssembler
{
    public static UpdateBovineCommand ToCommandFromResource(int id, UpdateBovineResource resource)
    {
        return new UpdateBovineCommand
        (
            Id: id,
            Name: resource.Name,
            Gender: resource.Gender,
            BirthDate: resource?.BirthDate,
            Breed: resource?.Breed,
            Location: resource?.Location,
            Lot: resource?.Lot,
            Status: resource?.Status,
            WeightKg: resource?.WeightKg ?? 0,
            StableId: resource?.StableId,
            fileData: resource?.fileData?.OpenReadStream() ?? null
        );
    }
}
