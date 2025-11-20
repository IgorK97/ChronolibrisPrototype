using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialDataForUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { 1L, null, "admin", "ADMIN" },
                    { 2L, null, "reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "deleted_at", "email", "email_confirmed", "family_name", "is_deleted", "last_entered_at", "lockout_enabled", "lockout_end", "name", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "registered_at", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { 1L, 0, "c1d345f6-2ca8-417a-a95e-ab3b59172ca5", null, "mail@mail.com", true, "KQWERTY", false, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), false, null, "AQWERTY", "MAIL@MAIL.COM", "MAINADMIN", "AQAAAAIAAYagAAAAEDJFJc162io4pjNy1E/Nf//bvX+ki234hGsZCcYkJjtPeR9CZQ1k/4T7Q2i+CWbPMg==", null, false, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "38229caf-27a1-4893-9ce8-7c4d24895361", false, "MainAdmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { 1L, 1L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}
