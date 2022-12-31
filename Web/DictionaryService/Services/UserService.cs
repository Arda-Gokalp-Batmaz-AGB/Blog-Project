using DictionaryService.Data.Repositories;
using DictionaryService.Models.BindingModel;
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

        public UserDTO FollowUser(FollowBindingModel model)
        {
            UserDTO user= null;
            string followerID = _repository.findIdByUserName(model.followerUserName);
            string followedID = _repository.findIdByUserName(model.followedUserName);
            if (_repository.FollowExists(followerID, followedID) == true)
            {
                user = _repository.UnFollowUser(followerID, followedID);
            }
            else
            {
                user = _repository.FollowUser(followerID, followedID);
            }
            return user;
        }

        public UserDTO getUserProfile(string username)
        {
            var user = _repository.GetUserProfileByUserName(username);
            return user;
        }
    }
}
