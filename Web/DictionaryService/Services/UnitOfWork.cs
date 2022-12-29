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

        public UnitOfWork(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        public async Task<Post> InsertNewPost(AddUpdatePostBindingModel model)
        {
            var post = await _postService.InsertPost(model);
            var comment = await _commentService.InsertFirstCommentOfPost(post.ID, model.FirstComment);
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
    }
}
