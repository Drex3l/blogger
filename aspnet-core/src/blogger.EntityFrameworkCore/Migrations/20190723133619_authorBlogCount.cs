using Microsoft.EntityFrameworkCore.Migrations;

namespace blogger.Migrations
{
    public partial class authorBlogCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogCount",
                table: "AppAuthor",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogCount",
                table: "AppAuthor");
        }
    }
}
