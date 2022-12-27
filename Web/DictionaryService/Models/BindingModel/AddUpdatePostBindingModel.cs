using System.ComponentModel.DataAnnotations;
namespace DictionaryService.Models.BindingModel
{
    public class AddUpdatePostBindingModel
    {
        [Required]
        public string Title{ get; set; }
        [Required]
        public string FirstComment { get; set; }
    }
}
