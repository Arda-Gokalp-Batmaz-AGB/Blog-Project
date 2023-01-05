using DictionaryService.Data.Entities;
using DictionaryService.Models.DTO;
using DictionaryService.Models.BindingModel;

namespace DictionaryService.Data.Repositories
{
    public interface IPostRepository
    {
        public List<PostDTO> GetAllPosts();
        public PostDTO GetPostById(int id);
        public string GetAuthorById(string id);
        public int FindPostIdByTitle(string Title);
        public Task<Post> GetPostComments(string username);

        public Task<Post> InsertPost(AddUpdatePostBindingModel model);
        public void DeletePost(int id);
        public void UpdatePost(Post updateApp);
    }
}
