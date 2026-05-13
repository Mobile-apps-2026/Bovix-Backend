using Bovix_Platform.IAM.Domain.Model.Commands;

namespace Bovix_Platform.IAM.Domain.Services
{
    public interface IUserCommandService
    {
        Task<string> Handle(SignUpCommand command);
        Task<string> Handle(SignInCommand command);
    }
}