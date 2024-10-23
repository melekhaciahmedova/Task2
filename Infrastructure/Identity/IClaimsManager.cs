using Domain.Entities;
using System.Security.Claims;
using ZeStudio;

namespace Infrastructure.Identity
{
    public interface IClaimsManager : IScopedInjector<IClaimsManager, ClaimsManager>
    {
        Guid GetCurrentUserId();
        IEnumerable<Claim> GetUserClaims(User user);
        Claim GetUserClaim(string claimType);
    }
}