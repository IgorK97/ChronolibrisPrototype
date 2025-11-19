using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(
                "ALTER TABLE books ALTER COLUMN is_fragment DROP DEFAULT; " +
                "ALTER TABLE books ALTER is_fragment TYPE bool USING CASE WHEN is_fragment=0 THEN FALSE ELSE TRUE END;" +
                "ALTER TABLE books ALTER COLUMN is_fragment SET DEFAULT FALSE;"
            );

            migrationBuilder.Sql(
                "ALTER TABLE books ALTER COLUMN is_available DROP DEFAULT; " +
                "ALTER TABLE books ALTER is_available TYPE bool USING CASE WHEN is_available=0 THEN FALSE ELSE TRUE END;" +
                "ALTER TABLE books ALTER COLUMN is_available SET DEFAULT FALSE;"
            );

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "books",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint"
                );

            migrationBuilder.AlterColumn<bool>(
                name: "is_fragment",
                table: "books",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "is_available",
                table: "books",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "file_path",
                table: "books",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "books",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "cover_path",
                table: "books",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<decimal>(
                name: "average_rating",
                table: "books",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(
                "ALTER TABLE books ALTER COLUMN is_fragment DROP DEFAULT; " +
                "ALTER TABLE books ALTER COLUMN is_fragment TYPE integer USING CASE WHEN is_fragment = TRUE THEN 1 ELSE 0 END; " +
                "ALTER TABLE books ALTER COLUMN is_fragment SET DEFAULT 0;"
            );

            migrationBuilder.Sql(
                "ALTER TABLE books ALTER COLUMN is_available DROP DEFAULT; " +
                "ALTER TABLE books ALTER COLUMN is_available TYPE integer USING CASE WHEN is_available = TRUE THEN 1 ELSE 0 END; " +
                "ALTER TABLE books ALTER COLUMN is_available SET DEFAULT 0;"
            );

            migrationBuilder.AlterColumn<long>(
                name: "title",
                table: "books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "is_fragment",
                table: "books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<long>(
                name: "is_available",
                table: "books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<long>(
                name: "file_path",
                table: "books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "description",
                table: "books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "cover_path",
                table: "books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "average_rating",
                table: "books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
