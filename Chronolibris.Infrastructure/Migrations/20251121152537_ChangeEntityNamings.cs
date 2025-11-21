using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntityNamings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_contents_books_book_id",
                table: "books_contents");

            migrationBuilder.DropForeignKey(
                name: "fk_books_contents_contents_content_id",
                table: "books_contents");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_roles_role_id",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_users_user_id",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "books_selections");

            migrationBuilder.DropTable(
                name: "books_shelves");

            migrationBuilder.DropTable(
                name: "contents_themes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_roles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_books_contents",
                table: "books_contents");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "user_tokens");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "user_role");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "user_logins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "user_claims");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "role_claims");

            migrationBuilder.RenameTable(
                name: "books_contents",
                newName: "book_content");

            migrationBuilder.RenameIndex(
                name: "ix_user_roles_role_id",
                table: "user_role",
                newName: "ix_user_role_role_id");

            migrationBuilder.RenameIndex(
                name: "ix_books_contents_content_id",
                table: "book_content",
                newName: "ix_book_content_content_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_role",
                table: "user_role",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_book_content",
                table: "book_content",
                columns: new[] { "book_id", "content_id" });

            migrationBuilder.CreateTable(
                name: "book_selection",
                columns: table => new
                {
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    selection_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_selection", x => new { x.book_id, x.selection_id });
                    table.ForeignKey(
                        name: "fk_book_selection_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_selection_selections_selection_id",
                        column: x => x.selection_id,
                        principalTable: "selections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_shelf",
                columns: table => new
                {
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    shelf_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_shelf", x => new { x.book_id, x.shelf_id });
                    table.ForeignKey(
                        name: "fk_book_shelf_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_shelf_shelves_shelf_id",
                        column: x => x.shelf_id,
                        principalTable: "shelves",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "content_theme",
                columns: table => new
                {
                    content_id = table.Column<long>(type: "bigint", nullable: false),
                    theme_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_content_theme", x => new { x.content_id, x.theme_id });
                    table.ForeignKey(
                        name: "fk_content_theme_contents_content_id",
                        column: x => x.content_id,
                        principalTable: "contents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_content_theme_themes_theme_id",
                        column: x => x.theme_id,
                        principalTable: "themes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp" },
                values: new object[] { "8d683dc9-e22a-4c43-a723-0fa90d46f18b", "1ad4d3c5-1545-4209-855c-5111e89936b4" });

            migrationBuilder.CreateIndex(
                name: "ix_contents_parent_content_id",
                table: "contents",
                column: "parent_content_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_parent_book_id",
                table: "books",
                column: "parent_book_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_selection_selection_id",
                table: "book_selection",
                column: "selection_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_shelf_shelf_id",
                table: "book_shelf",
                column: "shelf_id");

            migrationBuilder.CreateIndex(
                name: "ix_content_theme_theme_id",
                table: "content_theme",
                column: "theme_id");

            migrationBuilder.AddForeignKey(
                name: "fk_book_content_books_book_id",
                table: "book_content",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_book_content_contents_content_id",
                table: "book_content",
                column: "content_id",
                principalTable: "contents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_books_books_parent_book_id",
                table: "books",
                column: "parent_book_id",
                principalTable: "books",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_contents_contents_parent_content_id",
                table: "contents",
                column: "parent_content_id",
                principalTable: "contents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_role_roles_role_id",
                table: "user_role",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_role_users_user_id",
                table: "user_role",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_book_content_books_book_id",
                table: "book_content");

            migrationBuilder.DropForeignKey(
                name: "fk_book_content_contents_content_id",
                table: "book_content");

            migrationBuilder.DropForeignKey(
                name: "fk_books_books_parent_book_id",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "fk_contents_contents_parent_content_id",
                table: "contents");

            migrationBuilder.DropForeignKey(
                name: "fk_user_role_roles_role_id",
                table: "user_role");

            migrationBuilder.DropForeignKey(
                name: "fk_user_role_users_user_id",
                table: "user_role");

            migrationBuilder.DropTable(
                name: "book_selection");

            migrationBuilder.DropTable(
                name: "book_shelf");

            migrationBuilder.DropTable(
                name: "content_theme");

            migrationBuilder.DropIndex(
                name: "ix_contents_parent_content_id",
                table: "contents");

            migrationBuilder.DropIndex(
                name: "ix_books_parent_book_id",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_role",
                table: "user_role");

            migrationBuilder.DropPrimaryKey(
                name: "pk_book_content",
                table: "book_content");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "user_tokens",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "user_role",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "user_logins",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "user_claims",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "role_claims",
                newName: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "book_content",
                newName: "books_contents");

            migrationBuilder.RenameIndex(
                name: "ix_user_role_role_id",
                table: "UserRoles",
                newName: "ix_user_roles_role_id");

            migrationBuilder.RenameIndex(
                name: "ix_book_content_content_id",
                table: "books_contents",
                newName: "ix_books_contents_content_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_roles",
                table: "UserRoles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_books_contents",
                table: "books_contents",
                columns: new[] { "book_id", "content_id" });

            migrationBuilder.CreateTable(
                name: "books_selections",
                columns: table => new
                {
                    books_id = table.Column<long>(type: "bigint", nullable: false),
                    selections_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books_selections", x => new { x.books_id, x.selections_id });
                    table.ForeignKey(
                        name: "fk_books_selections_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_books_selections_selections_selections_id",
                        column: x => x.selections_id,
                        principalTable: "selections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books_shelves",
                columns: table => new
                {
                    books_id = table.Column<long>(type: "bigint", nullable: false),
                    shelves_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books_shelves", x => new { x.books_id, x.shelves_id });
                    table.ForeignKey(
                        name: "fk_books_shelves_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_books_shelves_shelves_shelves_id",
                        column: x => x.shelves_id,
                        principalTable: "shelves",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contents_themes",
                columns: table => new
                {
                    contents_id = table.Column<long>(type: "bigint", nullable: false),
                    themes_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contents_themes", x => new { x.contents_id, x.themes_id });
                    table.ForeignKey(
                        name: "fk_contents_themes_contents_contents_id",
                        column: x => x.contents_id,
                        principalTable: "contents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contents_themes_themes_themes_id",
                        column: x => x.themes_id,
                        principalTable: "themes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "concurrency_stamp", "security_stamp" },
                values: new object[] { "c1d345f6-2ca8-417a-a95e-ab3b59172ca5", "38229caf-27a1-4893-9ce8-7c4d24895361" });

            migrationBuilder.CreateIndex(
                name: "ix_books_selections_selections_id",
                table: "books_selections",
                column: "selections_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_shelves_shelves_id",
                table: "books_shelves",
                column: "shelves_id");

            migrationBuilder.CreateIndex(
                name: "ix_contents_themes_themes_id",
                table: "contents_themes",
                column: "themes_id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_contents_books_book_id",
                table: "books_contents",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_books_contents_contents_content_id",
                table: "books_contents",
                column: "content_id",
                principalTable: "contents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_roles_role_id",
                table: "UserRoles",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_users_user_id",
                table: "UserRoles",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
