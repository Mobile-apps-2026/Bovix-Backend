using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public static class BovineResourceFromEntityAssembler
{
    public static BovineResource ToResourceFromEntity(Bovine entity)
    {
        return new BovineResource(entity.Id,
            entity.Name,
            entity.Gender,
            entity.BirthDate,
            entity.Breed,
            entity.Location,
            entity.Lot,
            entity.Status,
            entity.WeightKg,
            entity.BovineImg,
            entity.StableId
        );
    }
}
