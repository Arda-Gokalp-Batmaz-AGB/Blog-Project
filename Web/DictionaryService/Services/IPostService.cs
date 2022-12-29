using DictionaryService.Models.DTO;
using DictionaryService.Models.BindingModel;
using DictionaryService.Data.Entities;
namespace DictionaryService.Data.Repositories
{
    public interface IPostService
    { 
    
        public List<PostDTO> ListAllPosts();
        public IEnumerable<PostDTO> ListFilteredPosts(string[] categories);
        public IEnumerable<CommentDTO> ListPostComments();
        public PostDTO GetPost(string param,object value);
        public Task<Post> InsertPost(AddUpdatePostBindingModel model);
    }
}
