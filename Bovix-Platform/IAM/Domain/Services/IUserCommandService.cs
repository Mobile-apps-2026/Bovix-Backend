using Bovix_Platform.IAM.Domain.Model.Commands;

namespace Bovix_Platform.IAM.Domain.Services
{
    public interface IUserCommandService
    {
        Task<(string token, string role)> Handle(SignUpCommand command);
        Task<(string token, string role)> Handle(SignInCommand command);
    }
}