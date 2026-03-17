using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexReadings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_reading_progresses_user_id",
                table: "reading_progresses");

            migrationBuilder.CreateIndex(
                name: "ix_reading_progresses_user_id_book_file_id",
                table: "reading_progresses",
                columns: new[] { "user_id", "book_file_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_reading_progresses_user_id_book_file_id",
                table: "reading_progresses");

            migrationBuilder.CreateIndex(
                name: "ix_reading_progresses_user_id",
                table: "reading_progresses",
                column: "user_id");
        }
    }
}
