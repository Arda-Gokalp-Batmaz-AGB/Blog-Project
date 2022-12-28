using DictionaryService.Data.Entities;
using System.ComponentModel.DataAnnotations;
namespace DictionaryService.Models.BindingModel
{
    public class AddUpdatePostBindingModel
    {
        [Required]
        public string Title{ get; set; }
        [Required]
        public Comment FirstComment { get; set; }
    }
}
