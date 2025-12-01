using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTokensFieldToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "refresh_token_expiry_time",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp", "refresh_token", "refresh_token_expiry_time" },
                values: new object[] { "da7298f5-8eef-483b-a4c1-41d25de2d9ab", "6c169f31-e30c-4ffa-b009-e0edf8ec625c", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "users");

            migrationBuilder.DropColumn(
                name: "refresh_token_expiry_time",
                table: "users");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp" },
                values: new object[] { "58761d95-42ef-45c1-80aa-e046eb27b2d0", "6199e1a8-7be1-406f-9439-ef37efa812b3" });
        }
    }
}
