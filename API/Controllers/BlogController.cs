using BlogDetails.Commands;
using BlogDetails.Queries;
using Domain.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Seedwork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController(IMediator mediator, IBlogQueries blogQueries) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IBlogQueries _blogQueries = blogQueries;

        [AuthorizeRoles(CustomRole.SuperAdmin)]
        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [AuthorizeRoles(CustomRole.SuperAdmin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [AuthorizeRoles(CustomRole.SuperAdmin, CustomRole.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get(int page, int size)
        {
            var data = await _blogQueries.GetAll(page, size);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var data = await _blogQueries.GetById(id);
            return Ok(data);
        }
    }
}