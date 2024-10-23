using Application.Repositories;
using BlogDetails.Commands;
using Domain.Entities;
using IdentityDetails.Auth;
using MediatR;

namespace BlogDetails.Handlers
{
    public class CreateBlogHandler(IUserManager userManager, IBlogRepository blogRepository) : IRequestHandler<CreateBlogCommand, bool>
    {
        private readonly IUserManager _userManager = userManager;
        private readonly IBlogRepository _blogRepository = blogRepository;
        public async Task<bool> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            //Login olmush user-in ID'ni ozunde saxlayir
            var userId = _userManager.GetCurrentUserId();
            var blog = new Blog();
            blog.SetDetails(request.Title, request.Description);
            blog.SetAuditFields(userId);
            await _blogRepository.AddAsync(blog);
            await _blogRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}