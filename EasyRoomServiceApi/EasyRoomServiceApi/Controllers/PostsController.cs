using EasyRoomServiceApi.Request;
using EasyRoomServiceApi.Response;
using EasyRoomServiceApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyRoomServiceApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService _service;

        public PostsController(PostService service)
        {
            _service = service;
        }

        // GET: api/Posts
        /// <summary>
        /// Get all posts form the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostResponse>>> GetPosts()
        {
            return await _service.GetAllPost();
        }

        // GET: api/Posts/5
        /// <summary>
        /// Filter Post based on the provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PostResponse>> GetPost(int id)
        {
            return await _service.GetPostByID(id);
        }



        // POST: api/Posts
        /// <summary>
        /// Add new posts to the database
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostPost(PostRequest post)
        {
            var result = await _service.CreatePost(post);

            if (!result)
            {
                return BadRequest("Wrong request pleast try again!");
            }

            return Ok("Post Created");
        }

        // DELETE: api/Posts/5
        /// <summary>
        /// Delete posts from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _service.DeletePostByID(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
