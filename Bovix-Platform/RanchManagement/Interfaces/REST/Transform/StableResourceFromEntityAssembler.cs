using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class StableResourceFromEntityAssembler
{
    public static StableResource ToResourceFromEntity(Stable stable)
    {
        return new StableResource(
            stable.Id,
            stable.Name,
            stable.Limit
        );
    }
}