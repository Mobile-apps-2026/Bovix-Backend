namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record CreateClinicalRecordCommand(
    int BovineId,
    DateTime RecordDate,
    string Diagnosis,
    string? Treatment,
    string? Severity,
    string? VeterinarianName);
