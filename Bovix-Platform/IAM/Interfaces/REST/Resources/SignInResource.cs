namespace Bovix_Platform.IAM.Interfaces.REST.Resources
{
    public record SignInResource(
        string Email,
        string Password
    );
}