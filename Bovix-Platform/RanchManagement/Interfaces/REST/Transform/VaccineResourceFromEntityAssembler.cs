using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class VaccineResourceFromEntityAssembler
{
    public static VaccineResource ToResourceFromEntity(Vaccine entity)
    {
        return new VaccineResource(entity.Id,
            entity.Name,
            entity.VaccineType,
            entity.VaccineDate,
            entity.VaccineImg,
            entity.BovineId
        );
    }
}