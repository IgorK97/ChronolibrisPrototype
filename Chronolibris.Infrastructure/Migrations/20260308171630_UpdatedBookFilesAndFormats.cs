using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBookFilesAndFormats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_digital_files_book_id",
                table: "digital_files");

            migrationBuilder.UpdateData(
                table: "formats",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "fb2");

            migrationBuilder.InsertData(
                table: "formats",
                columns: new[] { "id", "name" },
                values: new object[] { 4, "txt" });

            migrationBuilder.CreateIndex(
                name: "ix_digital_files_book_id_is_readable",
                table: "digital_files",
                columns: new[] { "book_id", "is_readable" },
                unique: true,
                filter: "\"is_readable\" = true");

            migrationBuilder.AddCheckConstraint(
                name: "ck_book_files_readable_format",
                table: "digital_files",
                sql: "NOT (\"is_readable\" = true) OR (\"format_id\" IN (1, 2))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_digital_files_book_id_is_readable",
                table: "digital_files");

            migrationBuilder.DropCheckConstraint(
                name: "ck_book_files_readable_format",
                table: "digital_files");

            migrationBuilder.DeleteData(
                table: "formats",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "formats",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "txt");

            migrationBuilder.CreateIndex(
                name: "ix_digital_files_book_id",
                table: "digital_files",
                column: "book_id");
        }
    }
}
