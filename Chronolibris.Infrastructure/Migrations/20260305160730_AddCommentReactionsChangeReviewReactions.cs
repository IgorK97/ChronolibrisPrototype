using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentReactionsChangeReviewReactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviews_ratings");

            migrationBuilder.CreateTable(
                name: "comment_reactions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    reaction_type = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comment_reactions", x => x.id);
                    table.CheckConstraint("ck_comment_reactions_reaction_type", "reaction_type IN (1, -1, 0)");
                    table.ForeignKey(
                        name: "fk_comment_reactions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "review_reactions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    review_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    reaction_type = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_review_reactions", x => x.id);
                    table.CheckConstraint("ck_review_reactions_reaction_type", "reaction_type IN (1, -1, 0)");
                    table.ForeignKey(
                        name: "fk_review_reactions_reviews_review_id",
                        column: x => x.review_id,
                        principalTable: "reviews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_review_reactions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_comment_reactions_user_id_comment_id",
                table: "comment_reactions",
                columns: new[] { "user_id", "comment_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_review_reactions_review_id",
                table: "review_reactions",
                column: "review_id");

            migrationBuilder.CreateIndex(
                name: "ix_review_reactions_user_id_review_id",
                table: "review_reactions",
                columns: new[] { "user_id", "review_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment_reactions");

            migrationBuilder.DropTable(
                name: "review_reactions");

            migrationBuilder.CreateTable(
                name: "reviews_ratings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reaction_type = table.Column<short>(type: "smallint", nullable: false),
                    review_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reviews_ratings", x => x.id);
                    table.CheckConstraint("ck_reviews_reactions_reaction_type", "reaction_type IN (1, -1, 0)");
                    table.ForeignKey(
                        name: "fk_reviews_ratings_reviews_review_id",
                        column: x => x.review_id,
                        principalTable: "reviews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_ratings_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_reviews_ratings_review_id",
                table: "reviews_ratings",
                column: "review_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_ratings_user_id_review_id",
                table: "reviews_ratings",
                columns: new[] { "user_id", "review_id" },
                unique: true);
        }
    }
}
