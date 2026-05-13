using Bovix_Platform.IAM.Domain.Model.Aggregates;
using Bovix_Platform.IAM.Domain.Model.Queries;

namespace Bovix_Platform.IAM.Domain.Services
{
    public interface IUserQueryService
    {
        Task<User?> Handle(GetUserByIdQuery query);
    }
}