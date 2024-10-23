using MediatR;

namespace BlogDetails.Commands
{
    public class DeleteBlogCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}