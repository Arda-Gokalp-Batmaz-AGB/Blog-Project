using DictionaryService.Data.Entities;
using System.ComponentModel.DataAnnotations;
namespace DictionaryService.Models.BindingModel
{
    public class AddUpdatePostBindingModel
    {
        [Required]
        public string AuthorID { get; set; }
        [Required]
        public string Title{ get; set; }
        [Required]
        public AddUpdateCommentBindingModel FirstComment { get; set; }
    //public Comment FirstComment { get; set; }
}
}
