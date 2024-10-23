using Domain.Entities;
using ZeStudio;

namespace IdentityDetails.Auth
{
    public interface IUserManager : IScopedInjector<IUserManager, UserManager>
    {
        Guid GetCurrentUserId();
        Task<User> GetCurrentUser();
        (string token, DateTime expiresAt) GenerateJwtToken(User user);
    }
}