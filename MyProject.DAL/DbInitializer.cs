using Microsoft.EntityFrameworkCore;
using MyProject.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//6
namespace MyProject.DAL
{
    internal class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        //7
        public void Seed()
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog { BlogId = 1, Url = "http://blogs.packtpub.com/dotnet" },
                new Blog { BlogId = 2, Url = "http://blogs.packtpub.com/dotnetcore" }
                );

            modelBuilder.Entity<Post>().HasData(
                new Post { PostId = 1, Title = "Dotnet 4.7 Released", Content = "Dotnet 4.7 Released Contents", PublishedDateTime = DateTime.Now, BlogId = 1 },
                new Post { PostId = 2, Title = ".NET Core 1.1 Released", Content = ".NET Core 1.1 Released Contents", PublishedDateTime = DateTime.Now, BlogId = 1 },
                new Post { PostId = 3, Title = "EF Core 1.1 Released", Content = "EF Core 1.1 Released Contents", PublishedDateTime = DateTime.Now, BlogId = 2 }
                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, Title = "finally!", Content="this is some very good news!", Author="Neo", PostId = 3 }
                );
        }
    }
}
