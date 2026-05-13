namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record UpdateClinicalRecordCommand(
    int Id,
    int BovineId,
    DateTime RecordDate,
    string Diagnosis,
    string? Treatment,
    string? Severity,
    string? VeterinarianName);
