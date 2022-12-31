using DictionaryService.Models.DTO;

namespace DictionaryService.Services
{
    public interface IUserService
    {
        public UserDTO getUserProfile(string username);
    }
}
