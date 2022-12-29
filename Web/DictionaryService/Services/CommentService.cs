using DictionaryService.Data.Repositories;
using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;

namespace DictionaryService.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _repository;
        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public void DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDTO> getFirstCommentOfPost(int postID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDTO> GetPostComments()
        {
            throw new NotImplementedException();
        }

        public Task<CommentDTO> GetPostComments(string username)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDTO> InsertComment(AddUpdateCommentBindingModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentDTO> InsertFirstCommentOfPost(int PostID,AddUpdateCommentBindingModel model)
        {
            var result = await _repository.InsertFirstCommentToPost(PostID, model);
            return result;
        }

        public void UpdateComment(CommentDTO updatedComment)
        {
            throw new NotImplementedException();
        }
    }
}
