using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bovix_Platform.RanchManagement.Domain.Model.Aggregates;

public class FeedingComponent
{
    [Required]
    public int Id { get; private set; }

    [Required]
    [StringLength(100)]
    public string Name { get; private set; }

    [Required]
    public int Percentage { get; private set; }

    [Required]
    public decimal AmountKg { get; private set; }

    [Required]
    public int FeedingPlanId { get; private set; }

    [ForeignKey(nameof(FeedingPlanId))]
    public FeedingPlan? FeedingPlan { get; private set; }

    private FeedingComponent() { }

    public FeedingComponent(string name, int percentage, decimal amountKg, int feedingPlanId)
    {
        Name = name;
        Percentage = percentage;
        AmountKg = amountKg;
        FeedingPlanId = feedingPlanId;
    }
}
