using Application.Repositories;
using BlogDetails.Commands;
using IdentityDetails.Auth;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogDetails.Handlers
{
    public class DeleteBlogHandler(IBlogRepository blogRepository, IUserManager userManager, AppDbContext context) : IRequestHandler<DeleteBlogCommand, bool>
    {
        private readonly IUserManager _userManager = userManager;
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly AppDbContext _context = context;
        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var userId = _userManager.GetCurrentUserId();
            var blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken)
                ?? throw new Exception("Blog with this id does not exist");
            _blogRepository.Delete(blog);
            await _blogRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}