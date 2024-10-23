using Domain.Entities;
using IdentityDetails.Queries;
using Infrastructure.Identity;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityDetails.Auth
{
    public class UserManager : IUserManager
    {
        private readonly JWTSettings _settings;
        private readonly IClaimsManager _claimsManager;
        private readonly IUserQueries _userQueries;

        public UserManager(IOptions<JWTSettings> settings, IClaimsManager claimsManager, IUserQueries userQueries)
        {
            _claimsManager = claimsManager ?? throw new ArgumentNullException(nameof(claimsManager));
            ArgumentNullException.ThrowIfNull(settings);
            _settings = settings.Value;
            _userQueries = userQueries;
        }

        public (string token, DateTime expiresAt) GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            claims.AddRange(_claimsManager.GetUserClaims(user));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresAt = DateTime.UtcNow.Date.AddDays(1).AddHours(1);


            var token = new JwtSecurityToken(
                _settings.Issuer,
                _settings.Audience,
                claims,
                expires: expiresAt,
                signingCredentials: creds
            );

            JwtSecurityTokenHandler tokenHandler = new();
            return (tokenHandler.WriteToken(token), expiresAt);
        }

        public Task<User> GetCurrentUser()
        {
            Guid currentUserId = GetCurrentUserId();
            return _userQueries.FindAsync(currentUserId);
        }

        public Guid GetCurrentUserId()
        {
            return _claimsManager.GetCurrentUserId();
        }
    }
}