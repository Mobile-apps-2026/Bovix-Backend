using Microsoft.EntityFrameworkCore;
using Bovix_Platform.IAM.Domain.Model.Aggregates;
using Bovix_Platform.IAM.Domain.Repositories;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Bovix_Platform.IAM.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepostory
    {
        public async Task<User?> FindByEmailAsync(string email)
        {
            return await context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}