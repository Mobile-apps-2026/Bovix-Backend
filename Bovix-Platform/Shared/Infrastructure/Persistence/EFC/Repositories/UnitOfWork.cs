using Bovix_Platform.Shared.Domain.Repositories;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}