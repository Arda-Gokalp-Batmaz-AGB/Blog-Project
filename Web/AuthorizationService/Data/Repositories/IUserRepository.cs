using AuthorizationService.Data.Entities;
using AuthorizationService.Models.BindingModel;
using AuthorizationService.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationService.Data.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<UserDTO> GetAllUsers();
        public Task<AppUser> GetUserByIdAsync(string id);
        public Task<AppUser> GetUserByNameAsync(string username);
        public Task<AppUser> GetUserByEmailAsync(string email);
        public Task<SignInResult> SignInUserAsync(string username,string password);
        public Task<IdentityResult> InsertUserAsync(AddUpdateRegisterUserBindingModel model);
        public void DeleteUser(int id);
        public void UpdateUser(AppUser updateApp);
    }
}
