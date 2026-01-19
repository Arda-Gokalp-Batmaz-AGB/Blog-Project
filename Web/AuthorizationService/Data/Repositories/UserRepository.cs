using AuthorizationService.Data.Entities;
using AuthorizationService.Models.BindingModel;
using AuthorizationService.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _userManager.Users.Select(x =>new UserDTO(x.UserName, x.Email, x.DateCreated)).ToList();
            return users;
        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<AppUser> GetUserByNameAsync(string username)
        {
            AppUser user = await _userManager.FindByNameAsync(username.ToString());
            return user;
        }

        public async Task<IdentityResult> InsertUserAsync(AddUpdateRegisterUserBindingModel model)
        {
            var user = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<SignInResult> SignInUserAsync(string username, string password)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result;
        }

        public void UpdateUser(AppUser updateApp)
        {
            throw new NotImplementedException();
        }


    }
}
