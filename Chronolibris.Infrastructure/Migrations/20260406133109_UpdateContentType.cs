using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //к нижнему регистру нужно еще привести
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:content_nature_enum", "unknown,document,work,analysis")
                .Annotation("Npgsql:Enum:person_role_kind", "content,book,both")
                .OldAnnotation("Npgsql:Enum:person_role_kind", "content,book,both");

            migrationBuilder.Sql(@"
                ALTER TABLE content_type
                ALTER COLUMN nature
                TYPE content_nature_enum
                USING nature::content_nature_enum;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE content_type
                ALTER COLUMN nature
                SET DEFAULT 'unknown'::content_nature_enum;
            ");

            //migrationBuilder.AlterColumn<int>(
            //    name: "nature",
            //    table: "content_type",
            //    type: "integer",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "character varying(50)",
            //    oldMaxLength: 50);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 1L,
            //    column: "nature",
            //    value: 1);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 2L,
            //    column: "nature",
            //    value: 1);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 3L,
            //    column: "nature",
            //    value: 1);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 4L,
            //    column: "nature",
            //    value: 1);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 5L,
            //    column: "nature",
            //    value: 1);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 6L,
            //    column: "nature",
            //    value: 1);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 7L,
            //    column: "nature",
            //    value: 1);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 8L,
            //    column: "nature",
            //    value: 1);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 9L,
            //    column: "nature",
            //    value: 1);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 10L,
            //    column: "nature",
            //    value: 2);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 11L,
            //    column: "nature",
            //    value: 2);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 12L,
            //    column: "nature",
            //    value: 2);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 13L,
            //    column: "nature",
            //    value: 2);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 14L,
            //    column: "nature",
            //    value: 2);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 15L,
            //    column: "nature",
            //    value: 2);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 16L,
            //    column: "nature",
            //    value: 2);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 17L,
            //    column: "nature",
            //    value: 2);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 18L,
            //    column: "nature",
            //    value: 2);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 19L,
            //    column: "nature",
            //    value: 3);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 20L,
            //    column: "nature",
            //    value: 3);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 21L,
            //    column: "nature",
            //    value: 3);

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 22L,
            //    column: "nature",
            //    value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE content_type
                ALTER COLUMN nature
                DROP DEFAULT;
            ");

            // Откатываем колонку обратно в varchar
            migrationBuilder.Sql(@"
                ALTER TABLE content_type
                ALTER COLUMN nature
                TYPE character varying(50)
                USING nature::text;
            ");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:person_role_kind", "content,book,both")
                .OldAnnotation("Npgsql:Enum:content_nature_enum", "unknown,document,work,analysis")
                .OldAnnotation("Npgsql:Enum:person_role_kind", "content,book,both");

            //migrationBuilder.AlterColumn<string>(
            //    name: "nature",
            //    table: "content_type",
            //    type: "character varying(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "integer");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 1L,
            //    column: "nature",
            //    value: "Document");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 2L,
            //    column: "nature",
            //    value: "Document");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 3L,
            //    column: "nature",
            //    value: "Document");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 4L,
            //    column: "nature",
            //    value: "Document");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 5L,
            //    column: "nature",
            //    value: "Document");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 6L,
            //    column: "nature",
            //    value: "Document");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 7L,
            //    column: "nature",
            //    value: "Document");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 8L,
            //    column: "nature",
            //    value: "Document");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 9L,
            //    column: "nature",
            //    value: "Document");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 10L,
            //    column: "nature",
            //    value: "Work");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 11L,
            //    column: "nature",
            //    value: "Work");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 12L,
            //    column: "nature",
            //    value: "Work");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 13L,
            //    column: "nature",
            //    value: "Work");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 14L,
            //    column: "nature",
            //    value: "Work");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 15L,
            //    column: "nature",
            //    value: "Work");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 16L,
            //    column: "nature",
            //    value: "Work");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 17L,
            //    column: "nature",
            //    value: "Work");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 18L,
            //    column: "nature",
            //    value: "Work");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 19L,
            //    column: "nature",
            //    value: "Analysis");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 20L,
            //    column: "nature",
            //    value: "Analysis");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 21L,
            //    column: "nature",
            //    value: "Analysis");

            //migrationBuilder.UpdateData(
            //    table: "content_type",
            //    keyColumn: "id",
            //    keyValue: 22L,
            //    column: "nature",
            //    value: "Unknown");
        }
    }
}
