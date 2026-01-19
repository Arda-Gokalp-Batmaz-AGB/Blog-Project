using AuthorizationService.Data.Entities;
using AuthorizationService.Models.BindingModel;
using AuthorizationService.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationService.Services
{
    public interface IUserService
    {
        public IEnumerable<UserDTO> ListUsers();
        public Task<UserDTO> GetUserAsync(string param, string paramType);
        public Task<IdentityResult> RegisterUserAsync(AddUpdateRegisterUserBindingModel userModel);
        public Task<UserDTO> LoginUserAsync(LoginBindingModel userModel);
        public bool RemoveUser(int id);
        public bool UpdateUser(AppUser updateUser);
    }
}
