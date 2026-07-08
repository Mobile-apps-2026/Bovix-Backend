using Microsoft.EntityFrameworkCore;
using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Bovix_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Bovix_Platform.RanchManagement.Infrastructure.Persistence.EFC.Repositories;

public class AppointmentRepository(AppDbContext ctx)
    : BaseRepository<Appointment>(ctx), IAppointmentRepository
{
    public async Task<Appointment?> FindNextAsync()
    {
        var now = DateTime.UtcNow;
        return await Context.Set<Appointment>()
            .Where(a => a.ScheduledAt >= now && a.Status == "SCHEDULED")
            .OrderBy(a => a.ScheduledAt)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Appointment>> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Appointment>().Where(a => a.UserId == userId).ToListAsync();
    }

    public async Task<Appointment?> FindNextByUserIdAsync(int userId)
    {
        var now = DateTime.UtcNow;
        return await Context.Set<Appointment>()
            .Where(a => a.UserId == userId && a.ScheduledAt >= now && a.Status == "SCHEDULED")
            .OrderBy(a => a.ScheduledAt)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Appointment>> FindByVetIdAsync(int vetId)
    {
        return await Context.Set<Appointment>().Where(a => a.VetId == vetId).ToListAsync();
    }
}
