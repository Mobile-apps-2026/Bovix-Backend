using Bovix_Platform.IAM.Domain.Model.Aggregates;
using Bovix_Platform.IAM.Domain.Model.Queries;
using Bovix_Platform.IAM.Domain.Repositories;
using Bovix_Platform.IAM.Domain.Services;

namespace Bovix_Platform.IAM.Application.QueryServices
{
    public class UserQueryService(
        IUserRepostory userRepository
        ) : IUserQueryService
    {
        public async Task<User?> Handle(GetUserByIdQuery query)
        {
            return await userRepository.FindByIdAsync(query.Id);
        }

        public async Task<IEnumerable<User>> Handle(GetUsersByRoleQuery query)
        {
            return await userRepository.FindAllByRoleAsync(query.Role);
        }
    }
}