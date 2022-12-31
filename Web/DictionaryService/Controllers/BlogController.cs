using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.RegularExpressions;
using DictionaryService.Services;
using DictionaryService.Data.Repositories;
using DictionaryService.Models.BindingModel;
using AuthorizationService.Helpers;
using DictionaryService.Models.DTO;

namespace AuthorizationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IUnitOfWork _service;
        public BlogController(IUnitOfWork service,ILogger<BlogController> logger)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] AddUpdatePostBindingModel model)
        {
            var result = await _service.InsertNewPost(model);
            if (result !=null)
            {
                return await Task.FromResult(Ok(result));
            }

            return await Task.FromResult(BadRequest());
        }
        [HttpGet("Posts")]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetAllPosts()
        {
            var posts = _service.ListPosts();
            return await Task.FromResult(Ok(posts));
        }
        [HttpGet("post/{post}")]
        public async Task<ActionResult<PostDTO>> GetPost(string post)
        {
            var foundedPost = _service.GetPostByTitle(post);
            if (foundedPost == null)
            {
                return await Task.FromResult(NotFound(new CustomError()
                {
                    name = "Invalid Post Title",
                    status = "404",
                    description = "There is not any post with given title"
                }));
            }
            return await Task.FromResult(Ok(foundedPost));
        }
        [HttpPost("InteractComment")]
        public async Task<IActionResult> InteractComment([FromBody] AddInteractionToComment model)
        {
            var result = _service.InteractComment(model);
            if (result != null)
            {
                return await Task.FromResult(Ok(result));
            }

            return await Task.FromResult(BadRequest());
        }
        [HttpGet("profile/{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = _service.GetUserProfile(username);
            if (user == null)
            {
                return await Task.FromResult(NotFound(new CustomError()
                {
                    name = "Invalid User",
                    status = "404",
                    description = "There is not any user with given name"
                }));
            }
            return await Task.FromResult(Ok(user));
        }
    }
}