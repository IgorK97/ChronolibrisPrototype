using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "parent_tag_id",
                table: "tags",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "relation_type_id",
                table: "tags",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tag_relation_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_relation_type", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "tag_relation_type",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1L, "Синонимия", "synonym" },
                    { 2L, "Часть/целое", "part_of" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_tags_parent_tag_id",
                table: "tags",
                column: "parent_tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_relation_type_id",
                table: "tags",
                column: "relation_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_tag_relation_type_name",
                table: "tag_relation_type",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_tags_tag_relation_type_relation_type_id",
                table: "tags",
                column: "relation_type_id",
                principalTable: "tag_relation_type",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_tags_tags_parent_tag_id",
                table: "tags",
                column: "parent_tag_id",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tags_tag_relation_type_relation_type_id",
                table: "tags");

            migrationBuilder.DropForeignKey(
                name: "fk_tags_tags_parent_tag_id",
                table: "tags");

            migrationBuilder.DropTable(
                name: "tag_relation_type");

            migrationBuilder.DropIndex(
                name: "ix_tags_parent_tag_id",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_tags_relation_type_id",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "parent_tag_id",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "relation_type_id",
                table: "tags");
        }
    }
}
