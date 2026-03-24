using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePositionInContentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "contents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "position",
                table: "contents",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "contents",
                keyColumn: "id",
                keyValue: 1L,
                column: "position",
                value: 0);

            migrationBuilder.UpdateData(
                table: "contents",
                keyColumn: "id",
                keyValue: 2L,
                column: "position",
                value: 0);
        }
    }
}
