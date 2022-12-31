using DictionaryService.Models.DTO;

namespace DictionaryService.Data.Repositories
{
    public interface IUserRepository
    {
        public UserDTO GetUserProfileByUserName(string username);
        public int getFollowerCount(string userID);
        public int getFollowedCount(string userID);
    }
}
