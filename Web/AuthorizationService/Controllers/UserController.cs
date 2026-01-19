using AuthorizationService.Models.BindingModel;
using AuthorizationService.Data.Entities;
using AuthorizationService.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AuthorizationService.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Text.RegularExpressions;
using AuthorizationService.Services;
using AuthorizationService.Helpers;

namespace AuthorizationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;
        public UserController(IUserService service,ILogger<UserController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] AddUpdateRegisterUserBindingModel model)
        {
            var result = await _service.RegisterUserAsync(model);
            if(result.Succeeded)
            {
                return await Task.FromResult(Ok("User Has Been Registered Sucessfully!"));
            }

            return await Task.FromResult(BadRequest(result.Errors.Select(x => new CustomError()
            {
                name = x.Code,
                status = "400",
                description = x.Description
            }).ToArray()));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("Users")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
        {
            var users = _service.ListUsers();
            return await Task.FromResult(Ok(users));
        }

        //[HttpGet("{username}")]
        //public async Task<ActionResult<UserDTO>> GetUser(string username)
        //{
        //    var user = await _service.GetUserAsync(username,"username");
        //    if(user == null)
        //    {
        //        return await Task.FromResult(NotFound(new CustomError()
        //        {
        //            name = "Invalid User",
        //            status = "404",
        //            description = "There is not any user with given name"
        //        }));
        //    }
        //    return await Task.FromResult(Ok(user));
        //}
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] LoginBindingModel model)
        {
            var resultUser = await _service.LoginUserAsync(model);
            if (resultUser != null)
            {
                return await Task.FromResult(Ok(resultUser));
            }
            return await Task.FromResult(Unauthorized(new CustomError()
            {
                name = "Invalid username/email or password",
                status = "401",
                description = "Invalid username/email or password"
            }));
        }
    }
}