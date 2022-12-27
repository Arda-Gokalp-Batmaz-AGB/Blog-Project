using DictionaryService.Data.Entities;
using DictionaryService.Models.DTO;
using DictionaryService.Models.BindingModel;

namespace DictionaryService.Data.Repositories
{
    public interface IPostRepository
    {
        public IEnumerable<PostDTO> GetAllPosts();
        public Task<Post> GetPostById(int id);
        public Task<Post> GetPostComments(string username);

        public Task<Post> InsertPost(AddUpdatePostBindingModel model);
        public void DeletePost(int id);
        public void UpdatePost(Post updateApp);
    }
}
