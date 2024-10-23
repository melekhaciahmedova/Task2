using Application.UseCases;
using Domain.Entities;
using SharedKernel.Domain.Seedwork;
using ZeStudio;

namespace Application.Repositories
{
    public interface IBlogRepository : IRepository<Blog>, IScopedInjector<IBlogRepository, BlogRepository>
    {
    }
}