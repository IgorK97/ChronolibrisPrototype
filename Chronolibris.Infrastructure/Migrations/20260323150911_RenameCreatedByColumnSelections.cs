using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameCreatedByColumnSelections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_selections_users_created_by",
                table: "selections");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "selections",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_selections_created_by",
                table: "selections",
                newName: "ix_selections_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_selections_users_user_id",
                table: "selections",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_selections_users_user_id",
                table: "selections");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "selections",
                newName: "created_by");

            migrationBuilder.RenameIndex(
                name: "ix_selections_user_id",
                table: "selections",
                newName: "ix_selections_created_by");

            migrationBuilder.AddForeignKey(
                name: "fk_selections_users_created_by",
                table: "selections",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
