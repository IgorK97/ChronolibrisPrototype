using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompositeIndexForShelfTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_shelves_user_id",
                table: "shelves");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_UserId_ShelfTypeId",
                table: "shelves",
                columns: new[] { "user_id", "shelf_type_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shelves_UserId_ShelfTypeId",
                table: "shelves");

            migrationBuilder.CreateIndex(
                name: "ix_shelves_user_id",
                table: "shelves",
                column: "user_id");
        }
    }
}
