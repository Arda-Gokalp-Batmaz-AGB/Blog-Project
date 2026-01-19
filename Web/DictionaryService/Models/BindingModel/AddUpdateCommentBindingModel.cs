using System.ComponentModel.DataAnnotations;
namespace DictionaryService.Models.BindingModel
{
    public class AddUpdateCommentBindingModel
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int PostID { get; set; }
        [Required]
        public int ParentID { get; set; }
        [Required]
        public string AuthorID { get; set; }
    }
}
