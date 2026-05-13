namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public class UpdateFeedingPlanResource
{
    public string Lot { get; set; }
    public decimal DailyRationKg { get; set; }
    public int AnimalCount { get; set; }
    public string? Notes { get; set; }
}
