﻿using DictionaryService.Data.Repositories;
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

        public CommentDTO createCommentOnPost(AddUpdateCommentBindingModel model)
        {
            string authorID = model.AuthorID;
            string text = model.Text;
            int parentID = model.ParentID;
            int postID = model.PostID;
            var comment = _repository.createNewCommentOnPost(postID, authorID, parentID, text);
            return comment;
        }

        public void DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public List<PostDTO> GetAllPostAllCommentsMatched(List<PostDTO> postList)
        {
            List<PostDTO> updatedPostList = new List<PostDTO>();
            foreach (PostDTO post in postList)
            {
                post.comments = GetPostComments(post.ID);
                updatedPostList.Add(post);
            }
            return updatedPostList;
        }

        public Task<CommentDTO> getFirstCommentOfPost(int postID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDTO> GetPostComments()
        {
            throw new NotImplementedException();
        }

        public List<CommentDTO> GetPostComments(int postID)
        {
            var comments = _repository.GetPostComments(postID);
            return comments;
        }

        public List<CommentDTO> getUserComments(string userID)
        {
            var comments = _repository.getUserComments(userID);
            return comments;
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

        public CommentDTO InteractComment(AddInteractionToComment model)
        {
            if (model.InteractionType == "like" || model.InteractionType == "dislike")
            {
                return _repository.InteractWithComment(model);
            }
            return null;
        }

        public void UpdateComment(CommentDTO updatedComment)
        {
            throw new NotImplementedException();
        }
    }
}
