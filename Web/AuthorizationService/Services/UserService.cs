using AuthorizationService.Data.Entities;
using AuthorizationService.Data.Repositories;
using AuthorizationService.Models;
using AuthorizationService.Models.BindingModel;
using AuthorizationService.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthorizationService.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private readonly JWTConfig _jwtConfig;
        public UserService(IUserRepository repository, IOptions<JWTConfig> jwtConfig)
        {
            _repository = repository;
            _jwtConfig = jwtConfig.Value;
        }

        public async Task<IdentityResult> RegisterUserAsync(AddUpdateRegisterUserBindingModel userModel)
        {
            var result = await _repository.InsertUserAsync(userModel);
            return result;
        }

        public async Task<UserDTO> GetUserAsync(string param, string paramType)
        {
            AppUser user = null;
            paramType = paramType.ToLower();
            if (paramType != "email")
            {
                if (paramType == "id")
                {
                    user = await _repository.GetUserByIdAsync(param);
                }
                else if (paramType == "username")
                {
                    user = await _repository.GetUserByNameAsync(param);
                }
            }
            else
            {
                user = await _repository.GetUserByEmailAsync(param);
            }
            if(user == null)
            {
                return null;
            }
            var appUser = new UserDTO(user.UserName, user.Email, user.DateCreated);
            return appUser;
        }

        public IEnumerable<UserDTO> ListUsers()
        {
            var users = _repository.GetAllUsers();
            return users;
        }

        public bool RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(AppUser updateUser)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> LoginUserAsync(LoginBindingModel userModel)
        {
            AppUser user = null;
            if (!userModel.EmailorUserName.Contains("@")) // username
            {
                user = await _repository.GetUserByNameAsync(userModel.EmailorUserName);
            }
            else // email
            {
                user = await _repository.GetUserByEmailAsync(userModel.EmailorUserName);
            }
            if(user == null)
            {
                return null;
            }
            SignInResult result = await _repository.SignInUserAsync(user.UserName, userModel.Password);
            if (result.Succeeded)
            {
                var appUser = new UserDTO(user.Id,user.UserName, user.Email, user.DateCreated);
                appUser.Token = GenerateToken(user);
                return appUser;
            }
            return null;
        }
        private string GenerateToken(AppUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.NameId,user.Id),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtConfig.Audience,
                Issuer = _jwtConfig.Issuer,
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
