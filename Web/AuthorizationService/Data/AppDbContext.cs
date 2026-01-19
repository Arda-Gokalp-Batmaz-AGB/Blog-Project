using AuthorizationService.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace AuthorizationService.Data
{
    public class AppDbContext: IdentityDbContext<AppUser,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();

            modelBuilder.Entity<IdentityRole>().ToTable("Role"); ;
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");

            modelBuilder.Entity<AppUser>().Ignore(c => c.AccessFailedCount)
                                                      .Ignore(c => c.LockoutEnabled)
                                                      .Ignore(c => c.LockoutEnd)
                                                      .Ignore(c => c.PhoneNumberConfirmed)
                                                      .Ignore(c => c.PhoneNumber)
                                                      .Ignore(c => c.ConcurrencyStamp)
                                                      .Ignore(c => c.SecurityStamp)
                                                      .Ignore(c => c.TwoFactorEnabled)
                                                      .Ignore(c => c.EmailConfirmed);//and so on...

            modelBuilder.Entity<AppUser>().ToTable("User");
        }
    }
}
