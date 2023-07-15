using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("GetAllComments")]
        public async Task<ActionResult<List<GetCommentDto>>> Get()
        {
            return Ok(await _commentService.GetAllComments());
        }

        [HttpGet("GetCommentById/{id}")]
        public async Task<ActionResult<GetCommentDto>> Get(int id)
        {
            var response = await _commentService.GetCommentById(id);
            if (response is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost("AddComment")]
        public async Task<ActionResult<GetCommentDto>> Post(AddCommentDto request)
        {
            return Ok(await _commentService.AddComment(request));
        }

        [HttpPut("UpdateComment")]
        public async Task<ActionResult<List<GetCommentDto>>> Put(UpdateCommentDto request)
        {
            var response = await _commentService.UpdateComment(request);
            if (response is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("DeleteComment/{id}")]
        public async Task<ActionResult<List<GetCommentDto>>> Delete(int id)
        {
            var response = await _commentService.DeleteComment(id);
            if (response is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
