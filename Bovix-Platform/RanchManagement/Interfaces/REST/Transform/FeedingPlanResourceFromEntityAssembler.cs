using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

public static class FeedingPlanResourceFromEntityAssembler
{
    public static FeedingPlanResource ToResourceFromEntity(FeedingPlan entity)
    {
        var components = entity.Components.Select(c =>
            new FeedingComponentResource(c.Id, c.Name, c.Percentage, c.AmountKg));
        return new FeedingPlanResource(
            entity.Id, entity.Lot, entity.DailyRationKg,
            entity.AnimalCount, entity.Notes, components);
    }
}
