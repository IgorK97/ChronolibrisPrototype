using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookFragment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "book_files");

            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "book_files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "processed_at",
                table: "book_files",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "version",
                table: "book_files",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "book_fragments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    book_file_id = table.Column<long>(type: "bigint", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    storage_url = table.Column<string>(type: "text", nullable: false),
                    start_pos = table.Column<int>(type: "integer", nullable: false),
                    end_pos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_fragments", x => x.id);
                    table.ForeignKey(
                        name: "fk_book_fragments_book_files_book_file_id",
                        column: x => x.book_file_id,
                        principalTable: "book_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_book_fragments_book_file_id_position",
                table: "book_fragments",
                columns: new[] { "book_file_id", "position" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_fragments");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "book_files");

            migrationBuilder.DropColumn(
                name: "processed_at",
                table: "book_files");

            migrationBuilder.DropColumn(
                name: "version",
                table: "book_files");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "book_files",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
