using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeReactionsAndReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_reviews_ratings_user_id",
                table: "reviews_ratings");

            migrationBuilder.DropIndex(
                name: "ix_reviews_user_id",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "average_rating",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "description",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "dislikes_count",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "likes_count",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "name",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "title",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "average_rating",
                table: "books");

            migrationBuilder.DropColumn(
                name: "ratings_count",
                table: "books");

            migrationBuilder.DropColumn(
                name: "reviews_count",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "reviews_ratings",
                newName: "reaction_type");

            migrationBuilder.AddColumn<string>(
                name: "review_text",
                table: "reviews",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_reviews_ratings_user_id_review_id",
                table: "reviews_ratings",
                columns: new[] { "user_id", "review_id" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "ck_reviews_reactions_reaction_type",
                table: "reviews_ratings",
                sql: "reaction_type IN (1, -1, 0)");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id_book_id",
                table: "reviews",
                columns: new[] { "user_id", "book_id" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "ck_review_rating",
                table: "reviews",
                sql: "score >=0.0 AND score<=5.0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_reviews_ratings_user_id_review_id",
                table: "reviews_ratings");

            migrationBuilder.DropCheckConstraint(
                name: "ck_reviews_reactions_reaction_type",
                table: "reviews_ratings");

            migrationBuilder.DropIndex(
                name: "ix_reviews_user_id_book_id",
                table: "reviews");

            migrationBuilder.DropCheckConstraint(
                name: "ck_review_rating",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "review_text",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "reaction_type",
                table: "reviews_ratings",
                newName: "score");

            migrationBuilder.AddColumn<long>(
                name: "average_rating",
                table: "reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "reviews",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "dislikes_count",
                table: "reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "likes_count",
                table: "reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "reviews",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "reviews",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "average_rating",
                table: "books",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "ratings_count",
                table: "books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "reviews_count",
                table: "books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "average_rating", "ratings_count", "reviews_count" },
                values: new object[] { 0m, 0L, 0L });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "average_rating", "ratings_count", "reviews_count" },
                values: new object[] { 0m, 0L, 0L });

            migrationBuilder.CreateIndex(
                name: "ix_reviews_ratings_user_id",
                table: "reviews_ratings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id",
                table: "reviews",
                column: "user_id");
        }
    }
}
