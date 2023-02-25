using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

//20
namespace MyProject.DAL
{
    public class DataContextFactory : IDesignTimeDbContextFactory<MyProjectDbContext>
    {
        public MyProjectDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyProjectDbContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyProjectDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            
            return new MyProjectDbContext(optionsBuilder.Options);
        }
    }
}
