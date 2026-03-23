using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixReportUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_reports_created_by",
                table: "reports",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_moderation_tasks_moderated_by",
                table: "moderation_tasks",
                column: "moderated_by");

            migrationBuilder.AddForeignKey(
                name: "fk_moderation_tasks_users_moderated_by",
                table: "moderation_tasks",
                column: "moderated_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_reports_users_created_by",
                table: "reports",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_moderation_tasks_users_moderated_by",
                table: "moderation_tasks");

            migrationBuilder.DropForeignKey(
                name: "fk_reports_users_created_by",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "ix_reports_created_by",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "ix_moderation_tasks_moderated_by",
                table: "moderation_tasks");
        }
    }
}
