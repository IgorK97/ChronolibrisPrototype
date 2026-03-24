using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTasksBooksAndBookFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "contents");

            migrationBuilder.DropColumn(
                name: "file_path",
                table: "books");

            migrationBuilder.DropColumn(
                name: "version",
                table: "book_files");

            migrationBuilder.AddColumn<int>(
                name: "version",
                table: "moderation_tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "version",
                table: "moderation_tasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "persons",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "contents",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file_path",
                table: "books",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "version",
                table: "book_files",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "id",
                keyValue: 1L,
                column: "file_path",
                value: "BuddismHistory/BuddismJapanGrig/MainFile.epub");

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "id",
                keyValue: 2L,
                column: "file_path",
                value: "EconomicHistory/StructureBrodel/MainFile.epub");

            migrationBuilder.UpdateData(
                table: "contents",
                keyColumn: "id",
                keyValue: 1L,
                column: "updated_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "contents",
                keyColumn: "id",
                keyValue: 2L,
                column: "updated_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "persons",
                keyColumn: "id",
                keyValue: 1L,
                column: "updated_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "persons",
                keyColumn: "id",
                keyValue: 2L,
                column: "updated_at",
                value: null);
        }
    }
}
