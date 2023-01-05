using System.ComponentModel.DataAnnotations;

namespace DictionaryService.Models.DTO
{
    public class PostDTO
    {
        public PostDTO(int ID,string Title,string AuthorID,List<CommentDTO> comments,string AuthorName)
        {
            this.ID = ID;
            this.Title = Title;
            this.AuthorID = AuthorID;
            this.comments = comments;
            this.AuthorName = AuthorName;
        }
        public int ID { get; set; }
        [StringLength(70)]
        public string? Title { get; set; }

        public string? AuthorID { get; set; }
        public string? AuthorName { get; set; }

        public List<CommentDTO> comments { get; set; }
    }
}
