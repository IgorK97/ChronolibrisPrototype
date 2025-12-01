using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTokensFieldToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp" },
                values: new object[] { "d9839f0c-e4c7-43c9-9518-a094a353a4f0", "f0e2bf89-c0ca-458e-944f-e25144fa3537" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp" },
                values: new object[] { "da7298f5-8eef-483b-a4c1-41d25de2d9ab", "6c169f31-e30c-4ffa-b009-e0edf8ec625c" });
        }
    }
}
