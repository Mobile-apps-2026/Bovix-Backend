namespace Bovix_Platform.RanchManagement.Interfaces.REST.Resources;

public record StableResource(
    int Id,
    string Name,
    int Limit/*,
    List<BovineResource> Bovines*/);