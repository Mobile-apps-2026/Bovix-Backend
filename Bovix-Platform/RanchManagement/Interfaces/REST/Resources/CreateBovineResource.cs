using Swashbuckle.AspNetCore.Annotations;

namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record CreateBovineResource(string Name,
    string Gender,
    DateTime? BirthDate,
    string? Breed,
    string? Location,
    string? Lot,
    string? Status,
    int WeightKg,
    int? StableId,
    IFormFile? fileData);
