using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPartialUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_reviews_user_id_book_id",
                table: "reviews");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id_book_id",
                table: "reviews",
                columns: new[] { "user_id", "book_id" },
                unique: true,
                filter: "\"review_status_id\" != 4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_reviews_user_id_book_id",
                table: "reviews");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id_book_id",
                table: "reviews",
                columns: new[] { "user_id", "book_id" },
                unique: true);
        }
    }
}
