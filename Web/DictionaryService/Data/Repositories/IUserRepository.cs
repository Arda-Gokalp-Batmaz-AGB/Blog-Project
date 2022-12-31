using DictionaryService.Models.DTO;

namespace DictionaryService.Data.Repositories
{
    public interface IUserRepository
    {
        public UserDTO GetUserProfileByUserName(string username);
        public int getFollowerCount(string userID);
        public int getFollowedCount(string userID);

        public UserDTO FollowUser(string followerID, string followedID);
        public UserDTO UnFollowUser(string followerID, string followedID);

        public string findIdByUserName(string username);

        public bool FollowExists(string follower, string followed);
    }
}
