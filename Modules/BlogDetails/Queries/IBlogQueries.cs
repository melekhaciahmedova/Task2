using Application.Response;
using BlogDetails.Response;
using ZeStudio;

namespace BlogDetails.Queries
{
    public interface IBlogQueries : IScopedInjector<IBlogQueries, BlogQueries>
    {
        Task<Pagination<BlogResponse>> GetAll(int page, int size);
        Task<BlogResponse> GetById(Guid id);
    }
}