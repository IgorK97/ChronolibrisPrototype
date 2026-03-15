using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTagTypeDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tag_types",
                keyColumn: "id",
                keyValue: 3L,
                column: "name",
                value: "Социум");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tag_types",
                keyColumn: "id",
                keyValue: 3L,
                column: "name",
                value: "Персоналия");
        }
    }
}
