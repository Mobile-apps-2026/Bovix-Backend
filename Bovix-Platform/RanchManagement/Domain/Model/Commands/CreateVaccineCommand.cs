namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record CreateVaccineCommand(
    string Name,
    string? VaccineType,
    DateTime? VaccineDate,
    string? VaccineImg,
    int BovineId,
    Stream? fileData);