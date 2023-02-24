/*22
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Web.Models;

namespace MyProject.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User> //4. add type 'User' to 'IdentityDbContext' (IdentityDbContext<User>)
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //5. modify the default names of the identity tables
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(
                entity => { entity.ToTable(name: "User"); }
                );
            builder.Entity<IdentityRole>(
                entity =>
                { entity.ToTable(name: "Role"); }
                );
            builder.Entity<IdentityUserRole<string>>(
                entity => { entity.ToTable("UserRoles"); }
                );
            builder.Entity<IdentityUserClaim<string>>(
                entity => { entity.ToTable("UserClaims"); }
                );
            builder.Entity<IdentityUserLogin<string>>(
                entity => { entity.ToTable("UserLogins"); }
                );
            builder.Entity<IdentityRoleClaim<string>>(
                entity => { entity.ToTable("RoleClaims"); }
                );
            builder.Entity<IdentityUserToken<string>>(
                entity => { entity.ToTable("UserTokens"); }
                );
        }
    }
}
*/