namespace Bovix_Platform.RanchManagement.Domain.Model.Commands;

public record CreateStableCommand(
    string Name,
    int Limit);