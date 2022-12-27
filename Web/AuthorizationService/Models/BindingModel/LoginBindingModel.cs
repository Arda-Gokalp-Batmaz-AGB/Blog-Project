using AuthorizationService.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationService.Models.BindingModel
{
    public class LoginBindingModel
    {
        [Required]
        public string Password { get; set; }

       // [ValidateMailUserName]
        [Required]
        public string EmailorUserName { get; set; }
        // public string UserName { get; set; }
        public bool RememberMe { get; set; }
    }
}
