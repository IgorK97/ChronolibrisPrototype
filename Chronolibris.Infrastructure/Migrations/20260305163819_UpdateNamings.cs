using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_comment_reactions_comment_id",
                table: "comment_reactions",
                column: "comment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_comment_reactions_comments_comment_id",
                table: "comment_reactions",
                column: "comment_id",
                principalTable: "comments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comment_reactions_comments_comment_id",
                table: "comment_reactions");

            migrationBuilder.DropIndex(
                name: "ix_comment_reactions_comment_id",
                table: "comment_reactions");
        }
    }
}
