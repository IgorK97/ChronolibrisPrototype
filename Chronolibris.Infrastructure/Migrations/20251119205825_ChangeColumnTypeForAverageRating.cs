using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnTypeForAverageRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                ALTER TABLE reviews
                ALTER COLUMN average_rating
                TYPE bigint
                USING average_rating::bigint;
            ");


            migrationBuilder.AlterColumn<long>(
                name: "average_rating",
                table: "reviews",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE reviews
                ALTER COLUMN average_rating
                TYPE numeric
                USING average_rating::numeric;
            ");

            migrationBuilder.AlterColumn<decimal>(
                name: "average_rating",
                table: "reviews",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
