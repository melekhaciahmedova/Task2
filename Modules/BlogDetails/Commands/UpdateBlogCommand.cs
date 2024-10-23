using MediatR;
using Microsoft.AspNetCore.Http;

namespace BlogDetails.Commands
{
    public class UpdateBlogCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}