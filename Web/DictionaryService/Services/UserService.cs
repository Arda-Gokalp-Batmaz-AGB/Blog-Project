using DictionaryService.Data.Repositories;
using DictionaryService.Models.DTO;

namespace DictionaryService.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public UserDTO getUserProfile(string username)
        {
            var user = _repository.GetUserProfileByUserName(username);
            return user;
        }
    }
}
