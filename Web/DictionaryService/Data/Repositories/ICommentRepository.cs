using DictionaryService.Models.DTO;
using DictionaryService.Models.BindingModel;
using DictionaryService.Data.Entities;

namespace DictionaryService.Data.Repositories
{
    public interface ICommentRepository
    {
        public List<CommentDTO> GetPostComments(int postID);
        public string GetAuthorById(string id);
        public Task<CommentDTO> getFirstCommentOfPost(int postID);

        public Task<CommentDTO> InsertCommentToPost(AddUpdateCommentBindingModel model);
        public Task<CommentDTO> InsertFirstCommentToPost(int PostID, AddUpdateCommentBindingModel model);
        public void DeleteComment(int id);
        public void UpdateComment(CommentDTO updatedComment);
    }
}
