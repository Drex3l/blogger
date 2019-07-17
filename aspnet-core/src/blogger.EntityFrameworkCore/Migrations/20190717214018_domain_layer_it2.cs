using Microsoft.EntityFrameworkCore.Migrations;

namespace blogger.Migrations
{
    public partial class domain_layer_it2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBlog_AppCategory_CatoryId",
                table: "AppBlog");

            migrationBuilder.DropForeignKey(
                name: "FK_AppBlog_AppAuthor_UserId",
                table: "AppBlog");

            migrationBuilder.DropIndex(
                name: "IX_AppBlog_CatoryId",
                table: "AppBlog");

            migrationBuilder.DropColumn(
                name: "CatoryId",
                table: "AppBlog");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppBlog");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppBlog",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AppBlog_UserId",
                table: "AppBlog",
                newName: "IX_AppBlog_AuthorId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AppBlog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "AppBlog",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppAuthor",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeactivated",
                table: "AppAuthor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AppBlog_CategoryId",
                table: "AppBlog",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlog_AppAuthor_AuthorId",
                table: "AppBlog",
                column: "AuthorId",
                principalTable: "AppAuthor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlog_AppCategory_CategoryId",
                table: "AppBlog",
                column: "CategoryId",
                principalTable: "AppCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBlog_AppAuthor_AuthorId",
                table: "AppBlog");

            migrationBuilder.DropForeignKey(
                name: "FK_AppBlog_AppCategory_CategoryId",
                table: "AppBlog");

            migrationBuilder.DropIndex(
                name: "IX_AppBlog_CategoryId",
                table: "AppBlog");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AppBlog");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "AppBlog");

            migrationBuilder.DropColumn(
                name: "IsDeactivated",
                table: "AppAuthor");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "AppBlog",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppBlog_AuthorId",
                table: "AppBlog",
                newName: "IX_AppBlog_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CatoryId",
                table: "AppBlog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppBlog",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppAuthor",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppBlog_CatoryId",
                table: "AppBlog",
                column: "CatoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlog_AppCategory_CatoryId",
                table: "AppBlog",
                column: "CatoryId",
                principalTable: "AppCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlog_AppAuthor_UserId",
                table: "AppBlog",
                column: "UserId",
                principalTable: "AppAuthor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
