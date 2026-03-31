using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bbk",
                table: "books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "udk",
                table: "books",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "bbk", "udk" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "bbk", "udk" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bbk",
                table: "books");

            migrationBuilder.DropColumn(
                name: "udk",
                table: "books");
        }
    }
}
