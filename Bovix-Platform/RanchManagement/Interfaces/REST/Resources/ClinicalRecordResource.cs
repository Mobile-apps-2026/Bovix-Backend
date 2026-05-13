namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record ClinicalRecordResource(
    int Id,
    int BovineId,
    DateTime RecordDate,
    string Diagnosis,
    string? Treatment,
    string Severity,
    string? VeterinarianName);
