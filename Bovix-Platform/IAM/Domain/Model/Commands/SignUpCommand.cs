namespace Bovix_Platform.IAM.Domain.Model.Commands
{
    public record SignUpCommand(
        string Username,
        string Password,
        string Email,
        string Role = "FARMER"
    );
}