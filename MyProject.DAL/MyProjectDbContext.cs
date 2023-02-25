using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.BL.Entities;

//17
namespace MyProject.DAL
{
    public class MyProjectDbContext : IdentityDbContext<User>
    {
        public DbSet<Blog>? Blog { get; set; }
        public DbSet<Post>? Post { get; set; }
        public DbSet<Comment>? Comment { get; set; }
        public DbSet<User>? User { get; set; }

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        { 
        }

        //modify the default names of the identity tables
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.HasDefaultSchema("Identity");

            builder.Entity<IdentityUser>(
                entity => { entity.ToTable(name: "User"); }
                );
            builder.Entity<IdentityRole>(
                entity => { entity.ToTable(name: "Role"); }
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

            //19. add relationships config
            builder.Entity<Blog>(
                //entity => { entity.ToTable("Blog"); }
                    )   
                .HasMany(b => b.Posts)
                .WithOne(p => p.Blog)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();

            builder.Entity<Post>()

                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
        }
    }
}