using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;

namespace DictionaryService.Services
{
    public interface ICommentService
    {
        public List<PostDTO> GetAllPostAllCommentsMatched(List<PostDTO> postList);
        public Task<CommentDTO> getFirstCommentOfPost(int postID);
        public List<CommentDTO> GetPostComments(int postID);

        public Task<CommentDTO> InsertComment(AddUpdateCommentBindingModel model);
        public Task<CommentDTO> InsertFirstCommentOfPost(int PostID, AddUpdateCommentBindingModel model);
        public void DeleteComment(int id);
        public void UpdateComment(CommentDTO updatedComment);

        public CommentDTO InteractComment(AddInteractionToComment model);
        public List<CommentDTO> getUserComments(string userID);
        public CommentDTO createCommentOnPost(AddUpdateCommentBindingModel model);

    }
}
