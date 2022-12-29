using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;

namespace DictionaryService.Services
{
    public interface ICommentService
    {
        public IEnumerable<CommentDTO> GetPostComments();
        public List<PostDTO> GetAllPostAllCommentsMatched(List<PostDTO> postList);
        public Task<CommentDTO> getFirstCommentOfPost(int postID);
        public Task<CommentDTO> GetPostComments(string username);

        public Task<CommentDTO> InsertComment(AddUpdateCommentBindingModel model);
        public Task<CommentDTO> InsertFirstCommentOfPost(int PostID, AddUpdateCommentBindingModel model);
        public void DeleteComment(int id);
        public void UpdateComment(CommentDTO updatedComment);
    }
}
