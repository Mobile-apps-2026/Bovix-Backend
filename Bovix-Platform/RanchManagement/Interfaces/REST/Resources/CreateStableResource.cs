namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record CreateStableResource(
    string Name,
    int Limit/*,
    List<BovineResource> Bovines*/);