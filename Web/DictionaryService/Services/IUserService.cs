using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;

namespace DictionaryService.Services
{
    public interface IUserService
    {
        public UserDTO getUserProfile(string username);
        public UserDTO FollowUser(FollowBindingModel model);

        public string findIDByUserName(string userName);
    }
}
