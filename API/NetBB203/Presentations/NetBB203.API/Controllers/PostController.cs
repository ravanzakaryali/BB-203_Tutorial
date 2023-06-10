using Application.Dtos;
using Application.Services.Abstracts;
using DataAccess.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace NetBB203.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        readonly IPostServcie _postServcie;

        public PostController(IPostServcie postServcie)
        {
            _postServcie = postServcie;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostCreateDto post)
        {
            try
            {
                return Ok(await _postServcie.CreateAsync(post));

            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseDto()
                {
                    Message = ex.Message,
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
