using System.ComponentModel.DataAnnotations;

namespace DictionaryService.Models.DTO
{
    public class PostDTO
    {
        public PostDTO(int ID,string Title,string AuthorID,List<CommentDTO> comments)
        {
            this.ID = ID;
            this.Title = Title;
            this.AuthorID = AuthorID;
            this.comments = comments;
        }
        public int ID { get; set; }
        [StringLength(70)]
        public string? Title { get; set; }

        public string? AuthorID { get; set; }

        public List<Comment> comments
    }
}
