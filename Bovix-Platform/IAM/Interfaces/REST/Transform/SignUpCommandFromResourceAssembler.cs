using Bovix_Platform.IAM.Domain.Model.Commands;
using Bovix_Platform.IAM.Interfaces.REST.Resources;

namespace Bovix_Platform.IAM.Interfaces.REST.Transform
{
    public static class SignUpCommandFromResourceAssembler
    {
        public static SignUpCommand ToCommandFromResource(SignUpResource resource)
        {
            return new SignUpCommand(
                resource.Username,
                resource.Password,
                resource.Email
            );
        }
    }
}