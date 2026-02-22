using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenBlacklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "token_blacklist",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    expiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_token_blacklist", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp" },
                values: new object[] { "88d4f82e-f15b-4d84-8bba-6875af640148", "0d832e3a-efd3-490a-8572-c544467f8d83" });

            migrationBuilder.CreateIndex(
                name: "IX_TokenBlacklist_Expiry",
                table: "token_blacklist",
                column: "expiry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "token_blacklist");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp" },
                values: new object[] { "d9839f0c-e4c7-43c9-9518-a094a353a4f0", "f0e2bf89-c0ca-458e-944f-e25144fa3537" });
        }
    }
}
