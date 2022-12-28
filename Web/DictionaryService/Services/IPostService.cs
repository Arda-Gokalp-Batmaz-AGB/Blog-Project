using DictionaryService.Models.DTO;
using DictionaryService.Models.BindingModel;
using DictionaryService.Data.Entities;
namespace DictionaryService.Data.Repositories
{
    public interface IPostService
    { 
    
        public IEnumerable<PostDTO> ListAllPosts();
        public IEnumerable<PostDTO> ListFilteredPosts(string[] categories);
        public IEnumerable<CommentDTO> ListPostComments();
        public Task<PostDTO> GetPost(int id);
        public Task<Post> InsertPost(AddUpdatePostBindingModel model);
    }
}
