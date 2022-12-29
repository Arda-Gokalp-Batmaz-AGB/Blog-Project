using DictionaryService.Data.Entities;
using DictionaryService.Data.Repositories;
using DictionaryService.Models.BindingModel;

namespace DictionaryService.Services
{
    public interface IUnitOfWork
    {
        public IPostService _postService{ get; }
        public ICommentService _commentService { get; }
        public Task<Post> InsertNewPost(AddUpdatePostBindingModel model);
    }
}
