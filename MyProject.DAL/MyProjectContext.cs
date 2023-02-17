using Microsoft.EntityFrameworkCore;
using MyProject.BL;

//4
namespace MyProject.DAL
{
    public class MyProjectContext: DbContext
    {
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Comment>? Comments { get; set; }

        //5
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
            optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MyProjectDB;Integrated Security=true");
        }

        //8
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            base.OnModelCreating(modelBuilder); 
            new DbInitializer(modelBuilder).Seed();
        }
    }
}