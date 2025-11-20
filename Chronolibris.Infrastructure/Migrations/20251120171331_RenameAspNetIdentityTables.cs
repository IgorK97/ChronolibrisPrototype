using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameAspNetIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_claims_asp_net_users_user_id",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_logins_asp_net_users_user_id",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_roles_asp_net_users_user_id",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "fk_bookmarks_asp_net_users_user_id",
                table: "bookmarks");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_asp_net_users_user_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_ratings_asp_net_users_user_id",
                table: "reviews_ratings");

            migrationBuilder.DropForeignKey(
                name: "fk_shelves_asp_net_users_user_id",
                table: "shelves");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_tokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_users",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_roles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_logins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_claims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_roles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_role_claims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "RoleClaims");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "UserRoles",
                newName: "ix_user_roles_role_id");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "UserLogins",
                newName: "ix_user_logins_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "UserClaims",
                newName: "ix_user_claims_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "RoleClaims",
                newName: "ix_role_claims_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_tokens",
                table: "UserTokens",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_roles",
                table: "UserRoles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_logins",
                table: "UserLogins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_claims",
                table: "UserClaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_roles",
                table: "Roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_claims",
                table: "RoleClaims",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_bookmarks_users_user_id",
                table: "bookmarks",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_users_user_id",
                table: "reviews",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_ratings_users_user_id",
                table: "reviews_ratings",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_claims_roles_role_id",
                table: "RoleClaims",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_shelves_users_user_id",
                table: "shelves",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_claims_users_user_id",
                table: "UserClaims",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_logins_users_user_id",
                table: "UserLogins",
                column: "user_id",
                principalTable: "Users",
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

            migrationBuilder.AddForeignKey(
                name: "fk_user_tokens_users_user_id",
                table: "UserTokens",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bookmarks_users_user_id",
                table: "bookmarks");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_users_user_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_ratings_users_user_id",
                table: "reviews_ratings");

            migrationBuilder.DropForeignKey(
                name: "fk_role_claims_roles_role_id",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_shelves_users_user_id",
                table: "shelves");

            migrationBuilder.DropForeignKey(
                name: "fk_user_claims_users_user_id",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_user_logins_users_user_id",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_roles_role_id",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_users_user_id",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_user_tokens_users_user_id",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_tokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_roles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_logins",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_claims",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_claims",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "ix_user_roles_role_id",
                table: "AspNetUserRoles",
                newName: "ix_asp_net_user_roles_role_id");

            migrationBuilder.RenameIndex(
                name: "ix_user_logins_user_id",
                table: "AspNetUserLogins",
                newName: "ix_asp_net_user_logins_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_user_claims_user_id",
                table: "AspNetUserClaims",
                newName: "ix_asp_net_user_claims_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_role_claims_role_id",
                table: "AspNetRoleClaims",
                newName: "ix_asp_net_role_claims_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_tokens",
                table: "AspNetUserTokens",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_users",
                table: "AspNetUsers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_roles",
                table: "AspNetUserRoles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_logins",
                table: "AspNetUserLogins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_claims",
                table: "AspNetUserClaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_roles",
                table: "AspNetRoles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_role_claims",
                table: "AspNetRoleClaims",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                table: "AspNetRoleClaims",
                column: "role_id",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_claims_asp_net_users_user_id",
                table: "AspNetUserClaims",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_logins_asp_net_users_user_id",
                table: "AspNetUserLogins",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_roles_asp_net_users_user_id",
                table: "AspNetUserRoles",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                table: "AspNetUserTokens",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_bookmarks_asp_net_users_user_id",
                table: "bookmarks",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_asp_net_users_user_id",
                table: "reviews",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_ratings_asp_net_users_user_id",
                table: "reviews_ratings",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_shelves_asp_net_users_user_id",
                table: "shelves",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
