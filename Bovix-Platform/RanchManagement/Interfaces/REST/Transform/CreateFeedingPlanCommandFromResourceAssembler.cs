using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public class CreateFeedingPlanCommandFromResourceAssembler
{
    public static CreateFeedingPlanCommand ToCommandFromResource(CreateFeedingPlanResource r) =>
        new(r.Lot, r.DailyRationKg, r.AnimalCount, r.Notes);
}
