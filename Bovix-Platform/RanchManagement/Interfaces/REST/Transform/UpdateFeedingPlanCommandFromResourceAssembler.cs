using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class UpdateFeedingPlanCommandFromResourceAssembler
{
    public static UpdateFeedingPlanCommand ToCommandFromResource(int id, UpdateFeedingPlanResource r) =>
        new(id, r.Lot, r.DailyRationKg, r.AnimalCount, r.Notes);
}
