using Bovix_Platform.IAM.Domain.Model.Aggregates;

namespace Bovix_Platform.IAM.Application.OutBoundServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        Task<int?> ValidateToken(string token);
    }
}