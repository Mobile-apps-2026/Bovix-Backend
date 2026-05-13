using Bovix_Platform.IAM.Domain.Model.Aggregates;
using Bovix_Platform.IAM.Interfaces.REST.Resources;

namespace Bovix_Platform.IAM.Interfaces.REST.Transform
{
    public class UserResourceFromEntityAssembler
    {
        public static UserResource ToResourceFromEntity(string token)
        {
            return new UserResource(token);
        }
    }
}