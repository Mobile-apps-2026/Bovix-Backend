using Bovix_Platform.IAM.Domain.Model.Commands;
using Bovix_Platform.IAM.Interfaces.REST.Resources;

namespace Bovix_Platform.IAM.Interfaces.REST.Transform
{
    public static class SignInCommandFromResourceAssembler
    {
        public static SignInCommand ToCommandFromResource(SignInResource resource)
        {
            return new SignInCommand(
                resource.Email,
                resource.Password
            );
        }
    }
}