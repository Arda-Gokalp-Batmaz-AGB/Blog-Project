using System.ComponentModel.DataAnnotations;

namespace DictionaryService.Models.DTO
{
    public class PostDTO
    {
        public PostDTO()
        {

        }
        public int ID { get; set; }
        [StringLength(70)]
        public string? Title { get; set; }

        public string? AuthorID { get; set; }
    }
}
