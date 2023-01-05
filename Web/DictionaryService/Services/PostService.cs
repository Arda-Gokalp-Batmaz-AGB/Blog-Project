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
        public PostDTO GetPost(string param, object value)
        {
            PostDTO post = null;
            int ID = -1;
            if (param == "ID")
            {
                ID = Convert.ToInt32(value);
            }
            else if(param == "Title")
            {
                ID = _repository.FindPostIdByTitle(value.ToString());
            }
            if(ID !=-1)
            {
                post = _repository.GetPostById(ID);
            }
            return post;
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

        public List<PostDTO> ListAllPosts()
        {
            var postList = _repository.GetAllPosts();
            return postList;
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
