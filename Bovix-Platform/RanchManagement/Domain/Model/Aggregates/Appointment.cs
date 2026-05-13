using System.ComponentModel.DataAnnotations;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;

namespace Bovix_Platform.RanchManagement.Domain.Model.Aggregates;

public class Appointment
{
    public static readonly string[] AllowedStatuses =
        { "SCHEDULED", "COMPLETED", "CANCELLED" };

    [Required]
    public int Id { get; private set; }

    [Required]
    [StringLength(150)]
    public string VeterinarianName { get; private set; }

    [Required]
    public DateTime ScheduledAt { get; private set; }

    [StringLength(20)]
    public string? Lot { get; private set; }

    [Required]
    [StringLength(20)]
    public string Status { get; private set; } = "SCHEDULED";

    [StringLength(500)]
    public string? Notes { get; private set; }

    private Appointment() { }

    public Appointment(CreateAppointmentCommand command)
    {
        VeterinarianName = command.VeterinarianName;
        ScheduledAt = command.ScheduledAt;
        Lot = command.Lot;
        Status = NormalizeStatus(command.Status);
        Notes = command.Notes;
    }

    public void Update(UpdateAppointmentCommand command)
    {
        VeterinarianName = command.VeterinarianName;
        ScheduledAt = command.ScheduledAt;
        Lot = command.Lot;
        Status = NormalizeStatus(command.Status);
        Notes = command.Notes;
    }

    private static string NormalizeStatus(string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) return "SCHEDULED";
        var s = raw.ToUpperInvariant();
        if (Array.IndexOf(AllowedStatuses, s) < 0)
            throw new ArgumentException($"Status must be one of: {string.Join(", ", AllowedStatuses)}");
        return s;
    }
}
