using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedShelfTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "shelf_type_id",
                table: "shelves",
                type: "bigint",
                nullable: false,
                defaultValue: 3L); //type 3 because before adding ShelfType ALL Shelves is concidered CUSTOM

            migrationBuilder.CreateTable(
                name: "shelf_types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shelf_types", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "shelf_types",
                columns: new[] { "id", "code" },
                values: new object[,]
                {
                    { 1L, "FAVORITES" },
                    { 2L, "READ" },
                    { 3L, "CUSTOM" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp" },
                values: new object[] { "a58bd136-1405-4f31-9add-99523a2bde5d", "ae8a161d-ac05-4edb-9b59-37cce64b67cb" });

            migrationBuilder.CreateIndex(
                name: "ix_shelves_shelf_type_id",
                table: "shelves",
                column: "shelf_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_shelves_shelf_types_shelf_type_id",
                table: "shelves",
                column: "shelf_type_id",
                principalTable: "shelf_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_shelves_shelf_types_shelf_type_id",
                table: "shelves");

            migrationBuilder.DropTable(
                name: "shelf_types");

            migrationBuilder.DropIndex(
                name: "ix_shelves_shelf_type_id",
                table: "shelves");

            migrationBuilder.DropColumn(
                name: "shelf_type_id",
                table: "shelves");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp" },
                values: new object[] { "fc1f1ab0-4786-41d4-a859-7e904483ac5a", "6f3da138-285b-4cde-8f48-9afdfa4654ea" });
        }
    }
}
