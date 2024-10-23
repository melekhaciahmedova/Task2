using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class ClaimsManager(IHttpContextAccessor httpContextAccessor) : IClaimsManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public Guid GetCurrentUserId()
        {
            var claim = GetUserClaim(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(claim.Value, out var currentUserId))
                throw new AuthenticationException("Can't parse claim value to required type");

            return currentUserId;
        }

        public IEnumerable<Claim> GetUserClaims(User user)
        {
            return new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new (ClaimTypes.Role, user.Role.Name)
            };
        }

        public Claim GetUserClaim(string claimType)
        {
            ClaimsPrincipal? user = _httpContextAccessor.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
                throw new AuthenticationException("User is not authenticated");

            Claim? claim = user.FindFirst(claimType);
            return claim ?? throw new AuthenticationException("User does not have required claim");
        }
    }
}