using MediatR;
using Microsoft.AspNetCore.Http;

namespace BlogDetails.Commands
{
    public class CreateBlogCommand : IRequest<bool>
    {
        public string Title {  get; set; }
        public string Description { get; set; }
    }
}