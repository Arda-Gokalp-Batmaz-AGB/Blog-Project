using DictionaryService.Data.Entities;
using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;

namespace DictionaryService.Data.Repositories
{
    public class PostService : IPostService
    {
        private IPostRepository _repository;
        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }
        public Task<PostDTO> GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> InsertPost(AddUpdatePostBindingModel model)
        {
            try 
            {
                Post post = await _repository.InsertPost(model);
                return post;
            }
            catch  (Exception ex) 
            {
                return null;
            }
        }

        public IEnumerable<PostDTO> ListAllPosts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostDTO> ListFilteredPosts(string[] categories)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDTO> ListPostComments()
        {
            throw new NotImplementedException();
        }
    }
}
