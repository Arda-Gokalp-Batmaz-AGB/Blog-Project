using DictionaryService.Data.Entities;
using DictionaryService.Models.DTO;

namespace DictionaryService.Data.Repositories
{
    public interface IPostRepository
    {
        public IEnumerable<PostDTO> GetAllPosts();
        public Task<Post> GetPostByIdAsync(int id);
        public Task<Post> GetPostCommentsAsync(string username);
        public void DeletePost(int id);
        public void UpdateUser(Post updateApp);
    }
}
