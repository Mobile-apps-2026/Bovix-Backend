using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class CreateStableCommandFromResourceAssembler
{
    public static CreateStableCommand ToCommandFromResource(CreateStableResource resource)
    {
        return new CreateStableCommand(
            resource.Name,
            resource.Limit
        );
    }
}