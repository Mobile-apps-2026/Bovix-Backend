namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record CreateClinicalRecordResource(
    int BovineId,
    DateTime RecordDate,
    string Diagnosis,
    string? Treatment,
    string? Severity,
    string? VeterinarianName);
