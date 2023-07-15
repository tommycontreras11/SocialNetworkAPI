using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAllPosts")]
        public async Task<ActionResult<List<GetPostDto>>> Get()
        {
            return Ok(await _postService.GetAllPosts());
        }

        [HttpGet("GetPostById/{id}")]
        public async Task<ActionResult<GetPostDto>> Get(int id)
        {
            var response = await _postService.GetPostById(id);
            if (response is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost("AddPost")]
        public async Task<ActionResult<List<GetPostDto>>> Post(AddPostDto request)
        {
            return Ok(await _postService.AddPost(request));
        }


        [HttpPut("UpdatePost")]
        public async Task<ActionResult<GetPostDto>> Put(UpdatePostDto request)
        {
            var response = await _postService.UpdatePost(request);
            if (response is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("DeletePost/{id}")]
        public async Task<ActionResult<List<GetPostDto>>> Delete(int id)
        {
            var response = await _postService.DeletePost(id);
            if (response is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
