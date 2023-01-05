using DictionaryService.Data.Entities;
using DictionaryService.Data.Repositories;
using DictionaryService.Models.BindingModel;
using DictionaryService.Models.DTO;

namespace DictionaryService.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPostService _postService { get; }

        public ICommentService _commentService { get; }
        public IUserService _userService { get; }

        public UnitOfWork(IPostService postService, ICommentService commentService, IUserService userService)
        {
            _postService = postService;
            _commentService = commentService;
            _userService = userService;
        }

        public async Task<Post> InsertNewPost(AddUpdatePostBindingModel model)
        {
            var post = await _postService.InsertPost(model);
            if(post != null)
            {
                var comment = await _commentService.InsertFirstCommentOfPost(post.ID, model.FirstComment);
            }
            return post;
        }

        public IEnumerable<PostDTO> ListPosts()
        {
            var rawPostList = _postService.ListAllPosts();
            var postsWithComments = _commentService.GetAllPostAllCommentsMatched(rawPostList);
            return postsWithComments;
        }

        public PostDTO GetPostByTitle(string postTitle)
        {
            PostDTO post = _postService.GetPost("Title", postTitle);
            if(post !=null)
            {
                List<CommentDTO> postComments = _commentService.GetPostComments(post.ID);
                post.comments = postComments;
            }

            return post;
        }

        public CommentDTO InteractComment(AddInteractionToComment model)
        {
            var comment = _commentService.InteractComment(model);
            return comment;
        }

        public UserDTO GetUserProfile(string username)
        {
            var user = _userService.getUserProfile(username);
            return user;
        }

        public UserDTO FollowUser(FollowBindingModel model)
        {
            var user = _userService.FollowUser(model);
            return user;
        }

        public List<CommentDTO> getUserComments(string userName)
        {
            string userID = _userService.findIDByUserName(userName);
            var comments = _commentService.getUserComments(userID);
            return comments;
        }

        public CommentDTO createComment(AddUpdateCommentBindingModel model)
        {
            var comment = _commentService.createCommentOnPost(model);
            return comment;
        }
    }
}
