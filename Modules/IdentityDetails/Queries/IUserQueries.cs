using Application.Response;
using Domain.Entities;
using IdentityDetails.Response;
using ZeStudio;

namespace IdentityDetails.Queries
{
    public interface IUserQueries : IScopedInjector<IUserQueries, UserQueries>
    {
        Task<Pagination<UserResponse>> GetAllUserResponses(int page = 1, int size = 10);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindAsync(Guid Id);
        Task<User> FindByRefreshToken(string refreshToken);
        Task<UserResponse> GetUserResponseAsync(Guid? userId);
    }
}