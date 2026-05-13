using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;

namespace Bovix_Platform.RanchManagement.Domain.Model.Aggregates;

public class ClinicalRecord
{
    public static readonly string[] AllowedSeverities =
        { "LOW", "MEDIUM", "HIGH" };

    [Required]
    public int Id { get; private set; }

    [Required]
    public int BovineId { get; private set; }

    [ForeignKey(nameof(BovineId))]
    public Bovine? Bovine { get; private set; }

    [Required]
    public DateTime RecordDate { get; private set; }

    [Required]
    [StringLength(200)]
    public string Diagnosis { get; private set; }

    [StringLength(500)]
    public string? Treatment { get; private set; }

    [Required]
    [StringLength(20)]
    public string Severity { get; private set; } = "LOW";

    [StringLength(150)]
    public string? VeterinarianName { get; private set; }

    private ClinicalRecord() { }

    public ClinicalRecord(CreateClinicalRecordCommand command)
    {
        BovineId = command.BovineId;
        RecordDate = command.RecordDate;
        Diagnosis = command.Diagnosis;
        Treatment = command.Treatment;
        Severity = NormalizeSeverity(command.Severity);
        VeterinarianName = command.VeterinarianName;
    }

    public void Update(UpdateClinicalRecordCommand command)
    {
        BovineId = command.BovineId;
        RecordDate = command.RecordDate;
        Diagnosis = command.Diagnosis;
        Treatment = command.Treatment;
        Severity = NormalizeSeverity(command.Severity);
        VeterinarianName = command.VeterinarianName;
    }

    private static string NormalizeSeverity(string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) return "LOW";
        var s = raw.ToUpperInvariant();
        if (Array.IndexOf(AllowedSeverities, s) < 0)
            throw new ArgumentException($"Severity must be one of: {string.Join(", ", AllowedSeverities)}");
        return s;
    }
}
