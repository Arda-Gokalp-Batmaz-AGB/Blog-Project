using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationService.Data.Entities
{
    public class AppUser: IdentityUser
    {
        [StringLength(30)]
        public string? Name { get; set; }
        [StringLength(30)]
        public string? SurName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [StringLength(800)]
        public string? About { get; set; }
        public string? Photo { get; set; }

    }
}
