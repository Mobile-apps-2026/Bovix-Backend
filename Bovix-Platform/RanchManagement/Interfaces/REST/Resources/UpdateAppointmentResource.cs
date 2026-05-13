namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public class UpdateAppointmentResource
{
    public string VeterinarianName { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string? Lot { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
}
