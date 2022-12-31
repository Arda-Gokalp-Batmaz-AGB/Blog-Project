using DictionaryService.Data.Entities;
using DictionaryService.Data.Repositories;
using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;

namespace DictionaryService.Services
{
    public interface IUnitOfWork
    {
        public IPostService _postService{ get; }
        public ICommentService _commentService { get; }
        public IEnumerable<PostDTO> ListPosts();
        public Task<Post> InsertNewPost(AddUpdatePostBindingModel model);
        public PostDTO GetPostByTitle(string postTitle);
        public CommentDTO InteractComment(AddInteractionToComment model);
        public UserDTO GetUserProfile(string username);

        public UserDTO FollowUser(FollowBindingModel model);
    }
}
