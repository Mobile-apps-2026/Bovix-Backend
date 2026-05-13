namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record UpdateBovineCommand(int Id,
    string Name,
    string Gender,
    DateTime? BirthDate,
    string? Breed,
    string? Location,
    string? Lot,
    string? Status,
    int WeightKg,
    int? StableId,
    Stream? fileData);
