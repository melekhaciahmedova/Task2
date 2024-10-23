using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases
{
    public class BlogRepository(AppDbContext context) : Repository<Blog>, IBlogRepository
    {
        public sealed override DbContext Context { get; protected set; } = context;
    }
}