using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReadingProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reading_progresses_books_book_id",
                table: "reading_progresses");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "reading_progresses",
                newName: "book_file_id");

            migrationBuilder.RenameIndex(
                name: "ix_reading_progresses_book_id",
                table: "reading_progresses",
                newName: "ix_reading_progresses_book_file_id");

            migrationBuilder.AddColumn<int>(
                name: "para_index",
                table: "reading_progresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_reading_progresses_book_files_book_file_id",
                table: "reading_progresses",
                column: "book_file_id",
                principalTable: "book_files",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reading_progresses_book_files_book_file_id",
                table: "reading_progresses");

            migrationBuilder.DropColumn(
                name: "para_index",
                table: "reading_progresses");

            migrationBuilder.RenameColumn(
                name: "book_file_id",
                table: "reading_progresses",
                newName: "book_id");

            migrationBuilder.RenameIndex(
                name: "ix_reading_progresses_book_file_id",
                table: "reading_progresses",
                newName: "ix_reading_progresses_book_id");

            migrationBuilder.AddForeignKey(
                name: "fk_reading_progresses_books_book_id",
                table: "reading_progresses",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
