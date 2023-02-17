using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.DAL.Migrations
{
    public partial class migr_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Url" },
                values: new object[] { 1, "http://blogs.packtpub.com/dotnet" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Url" },
                values: new object[] { 2, "http://blogs.packtpub.com/dotnetcore" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Content", "PublishedDateTime", "Title" },
                values: new object[] { 1, 1, "Dotnet 4.7 Released Contents", new DateTime(2023, 2, 16, 14, 0, 24, 266, DateTimeKind.Local).AddTicks(7128), "Dotnet 4.7 Released" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Content", "PublishedDateTime", "Title" },
                values: new object[] { 2, 1, ".NET Core 1.1 Released Contents", new DateTime(2023, 2, 16, 14, 0, 24, 266, DateTimeKind.Local).AddTicks(7140), ".NET Core 1.1 Released" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Content", "PublishedDateTime", "Title" },
                values: new object[] { 3, 2, "EF Core 1.1 Released Contents", new DateTime(2023, 2, 16, 14, 0, 24, 266, DateTimeKind.Local).AddTicks(7141), "EF Core 1.1 Released" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2);
        }
    }
}
