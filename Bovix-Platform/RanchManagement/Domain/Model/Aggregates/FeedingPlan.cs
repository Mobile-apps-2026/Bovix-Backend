using System.ComponentModel.DataAnnotations;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;

namespace Bovix_Platform.RanchManagement.Domain.Model.Aggregates;

public class FeedingPlan
{
    [Required]
    public int Id { get; private set; }

    [Required]
    [StringLength(20)]
    public string Lot { get; private set; }

    [Required]
    public decimal DailyRationKg { get; private set; }

    [Required]
    public int AnimalCount { get; private set; }

    [StringLength(300)]
    public string? Notes { get; private set; }

    public List<FeedingComponent> Components { get; private set; } = new();

    private FeedingPlan() { }

    public FeedingPlan(CreateFeedingPlanCommand command)
    {
        Lot = command.Lot;
        DailyRationKg = command.DailyRationKg;
        AnimalCount = command.AnimalCount;
        Notes = command.Notes;
    }

    public void Update(UpdateFeedingPlanCommand command)
    {
        Lot = command.Lot;
        DailyRationKg = command.DailyRationKg;
        AnimalCount = command.AnimalCount;
        Notes = command.Notes;
    }
}
