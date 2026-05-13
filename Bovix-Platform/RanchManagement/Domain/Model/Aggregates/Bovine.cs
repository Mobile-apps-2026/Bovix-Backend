using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;

namespace Bovix_Platform.RanchManagement.Domain.Model.Aggregates;

public class Bovine
{
    /// <summary>
    /// Allowed status values aligned with the Bovix mobile frontend.
    /// </summary>
    public static readonly string[] AllowedStatuses =
        { "HEALTHY", "MONITORED", "QUARANTINE", "DECEASED" };

    /// <summary>
    /// Entity Identifier
    /// </summary>
    [Required]
    public int Id { get; private set; }

    /// <summary>
    /// Name of the Bovine
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Name { get; private set; }

    /// <summary>
    /// Gender of the Bovine (MALE or FEMALE)
    /// </summary>
    [Required]
    [StringLength(10)]
    public string Gender { get; private set; }

    /// <summary>
    /// Date of Birth of the Bovine
    /// </summary>
    [Required]
    public DateTime? BirthDate { get; private set; }

    /// <summary>
    /// Breed of the Bovine
    /// </summary>
    [Required]
    [StringLength(100)]
    public string? Breed { get; private set; }

    /// <summary>
    /// Actual Location of the Bovine
    /// </summary>
    [Required]
    [StringLength(100)]
    public string? Location { get; private set; }

    /// <summary>
    /// Lot identifier (e.g. "A", "B", "C") used to group animals in the mobile UI.
    /// </summary>
    [StringLength(20)]
    public string? Lot { get; private set; }

    /// <summary>
    /// Current health status. One of: HEALTHY, MONITORED, QUARANTINE, DECEASED.
    /// </summary>
    [Required]
    [StringLength(20)]
    public string Status { get; private set; } = "HEALTHY";

    /// <summary>
    /// Live weight of the animal in kilograms.
    /// </summary>
    [Required]
    public int WeightKg { get; private set; }

    /// <summary>
    /// Stable Identifier As Foreign Key
    /// </summary>
    [Required]
    public int? StableId { get; private set; }
    /// <summary>
    /// Instancing the Stable Entity for the Foreign Key
    /// </summary>
    [ForeignKey(nameof(StableId))]
    public Stable? Stable { get; private set; }

    /// <summary>
    /// Bovine Image
    /// </summary>
    [Required]
    [StringLength(300)]
    public string? BovineImg { get; private set; }

    // Default constructor for EF Core
    private Bovine() { }

    // Constructor with parameters
    public Bovine(CreateBovineCommand command)
    {
        ValidateGender(command.Gender);
        var status = NormalizeStatus(command.Status);

        Name = command.Name;
        Gender = command.Gender.ToUpperInvariant();
        BirthDate = command.BirthDate;
        Breed = command.Breed;
        Location = command.Location;
        Lot = command.Lot;
        Status = status;
        WeightKg = command.WeightKg;
        BovineImg = command.BovineImg;
        StableId = command.StableId;
    }

    //Update Bovine
    public void Update(UpdateBovineCommand command)
    {
        ValidateGender(command.Gender);
        var status = NormalizeStatus(command.Status);

        Name = command.Name;
        Gender = command.Gender.ToUpperInvariant();
        BirthDate = command.BirthDate;
        Breed = command.Breed;
        Location = command.Location;
        Lot = command.Lot;
        Status = status;
        WeightKg = command.WeightKg;
        StableId = command.StableId;
    }

    private static void ValidateGender(string gender)
    {
        var g = gender?.ToUpperInvariant();
        if (g != "MALE" && g != "FEMALE")
            throw new ArgumentException("Gender must be either 'MALE' or 'FEMALE'");
    }

    private static string NormalizeStatus(string? rawStatus)
    {
        if (string.IsNullOrWhiteSpace(rawStatus)) return "HEALTHY";
        var s = rawStatus.ToUpperInvariant();
        if (Array.IndexOf(AllowedStatuses, s) < 0)
            throw new ArgumentException(
                $"Status must be one of: {string.Join(", ", AllowedStatuses)}");
        return s;
    }
}
