using System.ComponentModel.DataAnnotations;
namespace DictionaryService.Data.Entities
{
    public class Post
    {
        public int ID { get; set; }
        [StringLength(70)]
        public string? Title { get; set; }

        public string? AuthorID { get; set; }
    }
}
