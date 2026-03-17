using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBookmark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bookmarks_books_book_id",
                table: "bookmarks");

            migrationBuilder.DropColumn(
                name: "mark",
                table: "bookmarks");

            migrationBuilder.DropColumn(
                name: "text",
                table: "bookmarks");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "bookmarks",
                newName: "book_file_id");

            migrationBuilder.RenameIndex(
                name: "ix_bookmarks_book_id",
                table: "bookmarks",
                newName: "ix_bookmarks_book_file_id");

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "bookmarks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "para_index",
                table: "bookmarks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_bookmarks_book_files_book_file_id",
                table: "bookmarks",
                column: "book_file_id",
                principalTable: "book_files",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bookmarks_book_files_book_file_id",
                table: "bookmarks");

            migrationBuilder.DropColumn(
                name: "note",
                table: "bookmarks");

            migrationBuilder.DropColumn(
                name: "para_index",
                table: "bookmarks");

            migrationBuilder.RenameColumn(
                name: "book_file_id",
                table: "bookmarks",
                newName: "book_id");

            migrationBuilder.RenameIndex(
                name: "ix_bookmarks_book_file_id",
                table: "bookmarks",
                newName: "ix_bookmarks_book_id");

            migrationBuilder.AddColumn<string>(
                name: "mark",
                table: "bookmarks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "bookmarks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "fk_bookmarks_books_book_id",
                table: "bookmarks",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
