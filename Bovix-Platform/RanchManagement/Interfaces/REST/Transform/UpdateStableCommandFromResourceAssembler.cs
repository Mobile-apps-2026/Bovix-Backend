using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class UpdateStableCommandFromResourceAssembler
{
    public static UpdateStableCommand ToCommandFromResource(int id, UpdateStableResource resource)
    {
        return new UpdateStableCommand
        (
            Id: id,
            Name: resource.Name,
            Limit: resource.Limit
        );
    }
}