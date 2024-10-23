using Application.Response;
using AutoMapper;
using BlogDetails.Response;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogDetails.Queries
{
    public class BlogQueries(AppDbContext context, IMapper mapper) : IBlogQueries
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task<Pagination<BlogResponse>> GetAll(int page, int size)
        {
            List<Blog> blogs = await _context
                 .Blogs
                 .Include(m => m.created_by)
                 .OrderByDescending(m => m.record_date)
                 .AsNoTracking()
                 .ToListAsync();
            int count = blogs.Count;
            var response = _mapper.Map<List<BlogResponse>>(blogs);
            Pagination<BlogResponse> result = new(response.ToList(), page, size, count);
            return result;
        }

        public async Task<BlogResponse> GetById(Guid id)
        {
            var data = await _context
                .Blogs
                .Include(m => m.created_by)
                .FirstOrDefaultAsync(b => b.Id == id)
                ?? throw new Exception($"Blog with id: {id} could not be found.");
            var response = _mapper.Map<BlogResponse>(data);
            return response;
        }
    }
}