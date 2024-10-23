using Application.Repositories;
using BlogDetails.Commands;
using IdentityDetails.Auth;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogDetails.Handlers
{
    public class UpdateBlogHandler(IBlogRepository blogRepository, IUserManager userManager, AppDbContext context) 
        : IRequestHandler<UpdateBlogCommand, bool>
    {
        private readonly IUserManager _userManager = userManager;
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly AppDbContext _context = context;
        public async Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var userId = _userManager.GetCurrentUserId();
            var blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken)
                ?? throw new Exception("Blog with this id doesnt exist!");
            blog.SetDetails(request.Title, request.Description);
            blog.SetEditFields(userId);
            _blogRepository.Update(blog);
            await _blogRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}