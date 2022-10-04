using LvvlStarterNetApi.Core.Models;
using LvvlStarterNetApi.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LvvlStarterNetApi.Api.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _BlogService;

        public BlogController(
            IBlogService BlogService
            )
        {
            _BlogService = BlogService;
        }

        /// <summary>
        /// Retrieves all Blogs from the database.
        /// </summary>
        /// <response code="200">Returns a list of all Blogs in the database.</response>
        /// <response code="404">Returns error.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<List<Blog>> Get() =>
            await _BlogService.GetAsync();

        /// <summary>
        /// Retrieves a single Blog by Id from the MongoDb.
        /// </summary>
        /// <response code="200">Returns the requested Blog.</response>
        /// <response code="404">Returns NotFound error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Blog>> GetById(string id)
        {
            var blog = await _BlogService.GetByIdAsync(id);

            if (blog is null)
            {
                return NotFound();
            }

            return blog;
        }

        /// <summary>
        /// Adds an Blog to the MongoDb.
        /// </summary>
        /// <response code="200">Returns the added Blog's Id as a string.</response>
        /// <response code="400">Returns NotFound error.</response>
        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<string>> Post(Blog Blog)
        {
            var id = await _BlogService.PostBlogAsync(Blog);

            if (id is null)
            {
                return NotFound();
            }

            return id;
        }


        /// <summary>
        /// Deletes an Blog to the MongoDb by a given Id.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task Delete(string id) =>
            await _BlogService.DeleteBlogAsync(id);

        /// <summary>
        /// Returns all comments for a post with passed Id.
        /// </summary>
        /// <response code="200">Returns list of comments on the requested Blog.</response>
        /// <response code="404">Returns NotFound error.</response>
        [HttpGet("{id}/comment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Comment>>> GetComments(string id)
        {
            var comments = await _BlogService.GetCommentsAsync(id);

            if (comments is null)
            {
                return NotFound();
            }

            return comments;
        }

        /// <summary>
        /// Create a new comment for a post with Id.
        /// </summary>
        [HttpPost("{id}/comment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task PostComment(Comment comment, string id) =>
            await _BlogService.PostCommentAsync(comment, id);
    }
}