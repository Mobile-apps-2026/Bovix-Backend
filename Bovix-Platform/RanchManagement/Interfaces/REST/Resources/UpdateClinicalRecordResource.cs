namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public class UpdateClinicalRecordResource
{
    public int BovineId { get; set; }
    public DateTime RecordDate { get; set; }
    public string Diagnosis { get; set; }
    public string? Treatment { get; set; }
    public string? Severity { get; set; }
    public string? VeterinarianName { get; set; }
}
