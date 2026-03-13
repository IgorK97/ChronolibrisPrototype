using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameBookFileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_digital_files_books_book_id",
                table: "digital_files");

            migrationBuilder.DropForeignKey(
                name: "fk_digital_files_formats_format_id",
                table: "digital_files");

            migrationBuilder.DropPrimaryKey(
                name: "pk_digital_files",
                table: "digital_files");

            migrationBuilder.RenameTable(
                name: "digital_files",
                newName: "book_files");

            migrationBuilder.RenameIndex(
                name: "ix_digital_files_format_id",
                table: "book_files",
                newName: "ix_book_files_format_id");

            migrationBuilder.RenameIndex(
                name: "ix_digital_files_book_id_is_readable",
                table: "book_files",
                newName: "ix_book_files_book_id_is_readable");

            migrationBuilder.AddPrimaryKey(
                name: "pk_book_files",
                table: "book_files",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_book_files_books_book_id",
                table: "book_files",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_book_files_formats_format_id",
                table: "book_files",
                column: "format_id",
                principalTable: "formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_book_files_books_book_id",
                table: "book_files");

            migrationBuilder.DropForeignKey(
                name: "fk_book_files_formats_format_id",
                table: "book_files");

            migrationBuilder.DropPrimaryKey(
                name: "pk_book_files",
                table: "book_files");

            migrationBuilder.RenameTable(
                name: "book_files",
                newName: "digital_files");

            migrationBuilder.RenameIndex(
                name: "ix_book_files_format_id",
                table: "digital_files",
                newName: "ix_digital_files_format_id");

            migrationBuilder.RenameIndex(
                name: "ix_book_files_book_id_is_readable",
                table: "digital_files",
                newName: "ix_digital_files_book_id_is_readable");

            migrationBuilder.AddPrimaryKey(
                name: "pk_digital_files",
                table: "digital_files",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_digital_files_books_book_id",
                table: "digital_files",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_digital_files_formats_format_id",
                table: "digital_files",
                column: "format_id",
                principalTable: "formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
