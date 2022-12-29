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

namespace AuthorizationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IPostService _service;
        public BlogController(IPostService service,ILogger<BlogController> logger)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] AddUpdatePostBindingModel model)
        {
            var result = await _service.InsertPost(model);
            if (result !=null)
            {
                return await Task.FromResult(Ok(result));
            }

            return await Task.FromResult(BadRequest());
        }
    }
}