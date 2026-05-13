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
}
