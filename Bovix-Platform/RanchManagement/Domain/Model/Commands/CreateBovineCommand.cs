namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record CreateBovineCommand(
    string Name,
    string Gender,
    DateTime? BirthDate,
    string? Breed,
    string? Location,
    string? Lot,
    string? Status,
    int WeightKg,
    string? BovineImg,
    int? StableId,
    Stream? fileData);
