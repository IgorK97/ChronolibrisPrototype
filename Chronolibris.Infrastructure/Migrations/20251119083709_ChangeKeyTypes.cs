using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKeyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                ALTER TABLE tags
                ALTER COLUMN tag_type_id
                TYPE integer
                USING tag_type_id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE tag_types
                ALTER COLUMN id
                TYPE integer
                USING id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE publishers
                ALTER COLUMN country_id
                TYPE integer
                USING country_id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE person_roles
                ALTER COLUMN id
                TYPE integer
                USING id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE participations
                ALTER COLUMN person_role_id
                TYPE integer
                USING person_role_id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE languages
                ALTER COLUMN id
                TYPE integer
                USING id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE countries
                ALTER COLUMN id
                TYPE integer
                USING id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE contents
                ALTER COLUMN language_id
                TYPE integer
                USING language_id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE contents
                ALTER COLUMN country_id
                TYPE integer
                USING country_id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE books
                ALTER COLUMN language_id
                TYPE integer
                USING language_id::integer;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE books
                ALTER COLUMN country_id
                TYPE integer
                USING country_id::integer;
            ");

            migrationBuilder.AlterColumn<long>(
                name: "tag_type_id",
                table: "tags",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "tag_types",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "country_id",
                table: "publishers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "person_roles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "person_role_id",
                table: "participations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "languages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "countries",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "language_id",
                table: "contents",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "country_id",
                table: "contents",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "language_id",
                table: "books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "country_id",
                table: "books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.Sql(@"
                    ALTER TABLE tags
                    ALTER COLUMN tag_type_id
                    TYPE bigint
                    USING tag_type_id::bigint;
                ");

            migrationBuilder.Sql(@"
                ALTER TABLE tag_types
                ALTER COLUMN id
                TYPE bigint
                USING id::bigint;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE publishers
                ALTER COLUMN country_id
                TYPE bigint
                USING country_id::bigint;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE person_roles
                ALTER COLUMN id
                TYPE bigint
                USING id::bigint;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE participations
                ALTER COLUMN person_role_id
                TYPE bigint
                USING person_role_id::bigint;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE languages
                ALTER COLUMN id
                TYPE bigint
                USING id::bigint;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE countries
                ALTER COLUMN id
                TYPE bigint
                USING id::bigint;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE contents
                ALTER COLUMN language_id
                TYPE bigint
                USING language_id::bigint;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE contents
                ALTER COLUMN country_id
                TYPE bigint
                USING country_id::bigint;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE books
                ALTER COLUMN language_id
                TYPE bigint
                USING language_id::bigint;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE books
                ALTER COLUMN country_id
                TYPE bigint
                USING country_id::bigint;
            ");

            migrationBuilder.AlterColumn<int>(
            name: "tag_type_id",
            table: "tags",
            type: "integer",
            nullable: false,
            oldClrType: typeof(long),
            oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "tag_types",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "country_id",
                table: "publishers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "person_roles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "person_role_id",
                table: "participations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "languages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "countries",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "language_id",
                table: "contents",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "country_id",
                table: "contents",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "language_id",
                table: "books",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "country_id",
                table: "books",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
