using Bovix_Platform.IAM.Domain.Model.Aggregates;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.IAM.Domain.Repositories
{
    public interface IUserRepostory : IBaseRepository<User>
    {
        Task<User?> FindByEmailAsync(string email);
    }
}