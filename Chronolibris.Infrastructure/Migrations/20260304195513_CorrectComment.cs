using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comment_books_book_id",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "fk_comment_comment_parent_comment_id",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "fk_comment_users_user_id",
                table: "comment");

            migrationBuilder.DropPrimaryKey(
                name: "pk_comment",
                table: "comment");

            migrationBuilder.RenameTable(
                name: "comment",
                newName: "comments");

            migrationBuilder.RenameIndex(
                name: "ix_comment_user_id",
                table: "comments",
                newName: "ix_comments_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_comment_parent_comment_id",
                table: "comments",
                newName: "ix_comments_parent_comment_id");

            migrationBuilder.RenameIndex(
                name: "ix_comment_book_id_created_at",
                table: "comments",
                newName: "ix_comments_book_id_created_at");

            migrationBuilder.AddPrimaryKey(
                name: "pk_comments",
                table: "comments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_books_book_id",
                table: "comments",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comments_parent_comment_id",
                table: "comments",
                column: "parent_comment_id",
                principalTable: "comments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_comments_users_user_id",
                table: "comments",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_books_book_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_comments_parent_comment_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_users_user_id",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_comments",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "comment");

            migrationBuilder.RenameIndex(
                name: "ix_comments_user_id",
                table: "comment",
                newName: "ix_comment_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_comments_parent_comment_id",
                table: "comment",
                newName: "ix_comment_parent_comment_id");

            migrationBuilder.RenameIndex(
                name: "ix_comments_book_id_created_at",
                table: "comment",
                newName: "ix_comment_book_id_created_at");

            migrationBuilder.AddPrimaryKey(
                name: "pk_comment",
                table: "comment",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comment_books_book_id",
                table: "comment",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_comment_comment_parent_comment_id",
                table: "comment",
                column: "parent_comment_id",
                principalTable: "comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_comment_users_user_id",
                table: "comment",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
