using DictionaryService.Data.Entities;
using DictionaryService.Data.Repositories;
using DictionaryService.Models.BindingModel;

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

        public IEnumerable<Models.DTO.PostDTO> ListPosts()
        {
            var rawPostList = _postService.ListAllPosts();
            var postsWithComments = _commentService.GetAllPostAllCommentsMatched(rawPostList)
            return postsWithComments;
        }
    }
}
