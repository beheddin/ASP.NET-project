using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.DAL.Migrations
{
    public partial class migr_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2023, 2, 16, 14, 12, 21, 90, DateTimeKind.Local).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2023, 2, 16, 14, 12, 21, 90, DateTimeKind.Local).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedDateTime",
                value: new DateTime(2023, 2, 16, 14, 12, 21, 90, DateTimeKind.Local).AddTicks(7925));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2023, 2, 16, 14, 9, 4, 650, DateTimeKind.Local).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2023, 2, 16, 14, 9, 4, 650, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedDateTime",
                value: new DateTime(2023, 2, 16, 14, 9, 4, 650, DateTimeKind.Local).AddTicks(992));
        }
    }
}
