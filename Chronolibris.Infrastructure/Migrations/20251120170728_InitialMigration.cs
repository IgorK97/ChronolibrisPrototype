using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    family_name = table.Column<string>(type: "text", nullable: false),
                    registered_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_entered_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person_roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image_path = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    country_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publishers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "selections",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_selections", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tag_types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "themes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    parent_theme_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_themes", x => x.id);
                    table.ForeignKey(
                        name: "fk_themes_themes_parent_theme_id",
                        column: x => x.parent_theme_id,
                        principalTable: "themes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shelves",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shelves", x => x.id);
                    table.ForeignKey(
                        name: "fk_shelves_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contents",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<long>(type: "bigint", nullable: false),
                    language_id = table.Column<long>(type: "bigint", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: true),
                    is_original = table.Column<bool>(type: "boolean", nullable: false),
                    is_translate = table.Column<bool>(type: "boolean", nullable: false),
                    parent_content_id = table.Column<long>(type: "bigint", nullable: true),
                    position = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contents", x => x.id);
                    table.ForeignKey(
                        name: "fk_contents_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contents_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    publisher_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_series", x => x.id);
                    table.ForeignKey(
                        name: "fk_series_publishers_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "publishers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    tag_type_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.id);
                    table.ForeignKey(
                        name: "fk_tags_tag_types_tag_type_id",
                        column: x => x.tag_type_id,
                        principalTable: "tag_types",
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

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<long>(type: "bigint", nullable: false),
                    language_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    year = table.Column<int>(type: "integer", nullable: true),
                    isbn = table.Column<string>(type: "text", nullable: true),
                    is_fragment = table.Column<bool>(type: "boolean", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    cover_path = table.Column<string>(type: "text", nullable: false),
                    is_available = table.Column<bool>(type: "boolean", nullable: false),
                    average_rating = table.Column<decimal>(type: "numeric", nullable: false),
                    ratings_count = table.Column<long>(type: "bigint", nullable: false),
                    reviews_count = table.Column<long>(type: "bigint", nullable: false),
                    parent_book_id = table.Column<long>(type: "bigint", nullable: true),
                    publisher_id = table.Column<long>(type: "bigint", nullable: true),
                    series_id = table.Column<long>(type: "bigint", nullable: true),
                    tag_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books", x => x.id);
                    table.ForeignKey(
                        name: "fk_books_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_books_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_books_publishers_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "publishers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_books_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_books_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bookmarks",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    mark = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bookmarks", x => x.id);
                    table.ForeignKey(
                        name: "fk_bookmarks_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bookmarks_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books_contents",
                columns: table => new
                {
                    content_id = table.Column<long>(type: "bigint", nullable: false),
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books_contents", x => new { x.book_id, x.content_id });
                    table.ForeignKey(
                        name: "fk_books_contents_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_books_contents_contents_content_id",
                        column: x => x.content_id,
                        principalTable: "contents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "participations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<long>(type: "bigint", nullable: false),
                    person_role_id = table.Column<long>(type: "bigint", nullable: false),
                    content_id = table.Column<long>(type: "bigint", nullable: true),
                    book_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participations", x => x.id);
                    table.ForeignKey(
                        name: "fk_participations_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_participations_contents_content_id",
                        column: x => x.content_id,
                        principalTable: "contents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_participations_person_roles_person_role_id",
                        column: x => x.person_role_id,
                        principalTable: "person_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_participations_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    score = table.Column<short>(type: "smallint", nullable: false),
                    average_rating = table.Column<long>(type: "bigint", nullable: false),
                    likes_count = table.Column<long>(type: "bigint", nullable: false),
                    dislikes_count = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_reviews_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews_ratings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    review_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    score = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reviews_ratings", x => x.id);
                    table.ForeignKey(
                        name: "fk_reviews_ratings_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_ratings_reviews_review_id",
                        column: x => x.review_id,
                        principalTable: "reviews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Россия" },
                    { 2L, "СССР" },
                    { 3L, "Российская империя" },
                    { 4L, "США" },
                    { 5L, "Франция" }
                });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Английский" },
                    { 2L, "Русский" },
                    { 3L, "Французский" },
                    { 4L, "Немецкий" }
                });

            migrationBuilder.InsertData(
                table: "person_roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Автор" },
                    { 2L, "Переводчик" },
                    { 3L, "Редактор" }
                });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "created_at", "description", "image_path", "name", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Советский и российский востоковед-японист, литературовед, переводчица...", "none", "Татьяна Петровна Григорьева", null },
                    { 2L, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Французский историк, член Французской академии...", "Brodel/MainFile.jpeg", "Фернан Поль Ахилл Бродель", null }
                });

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "id", "country_id", "created_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", "Прогресс", null },
                    { 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", "Восточная литература", null }
                });

            migrationBuilder.InsertData(
                table: "selections",
                columns: new[] { "id", "created_at", "description", "is_active", "name", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "", true, "Экономическая история", null },
                    { 2L, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "", true, "История культуры", null },
                    { 3L, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "", true, "История мира", null }
                });

            migrationBuilder.InsertData(
                table: "tag_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Место" },
                    { 2L, "Время" },
                    { 3L, "Персоналия" }
                });

            migrationBuilder.InsertData(
                table: "themes",
                columns: new[] { "id", "name", "parent_theme_id" },
                values: new object[,]
                {
                    { 1L, "Отечественная история", null },
                    { 2L, "История религии", null },
                    { 3L, "История культуры", null },
                    { 4L, "Социально-экономическая история", null }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "average_rating", "country_id", "cover_path", "created_at", "description", "file_path", "isbn", "is_available", "is_fragment", "language_id", "parent_book_id", "publisher_id", "ratings_count", "reviews_count", "series_id", "tag_id", "title", "updated_at", "year" },
                values: new object[,]
                {
                    { 1L, 0m, 1L, "BuddismHistory/BuddismJapanGrig/MainFile.png", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Монография является первой в отечественной литературе попыткой...", "BuddismHistory/BuddismJapanGrig/MainFile.epub", null, true, false, 2L, null, 2L, 0L, 0L, null, null, "Буддизм в Японии", null, 1993 },
                    { 2L, 0m, 1L, "EconomicHistory/StructureBrodel/MainFile.png", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Это — второе крупное исследование Ф. Броделя...", "EconomicHistory/StructureBrodel/MainFile.epub", null, true, false, 2L, null, 1L, 0L, 0L, null, null, "Структуры повседневности: возможное и невозможное", null, 1986 }
                });

            migrationBuilder.InsertData(
                table: "contents",
                columns: new[] { "id", "country_id", "created_at", "description", "is_original", "is_translate", "language_id", "parent_content_id", "position", "title", "updated_at", "year" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Монография является первой в отечественной литературе попыткой проследить процесс становления японского буддизма...", true, false, 2L, null, 0, "Буддизм в Японии", null, 1993 },
                    { 2L, 5L, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Это — второе крупное исследование Ф. Броделя. Первое — «Средиземное море и мир Средиземноморья в эпоху Филиппа II»...", false, true, 2L, null, 0, "Структуры повседневности: возможное и невозможное", null, 1979 }
                });

            migrationBuilder.InsertData(
                table: "books_contents",
                columns: new[] { "book_id", "content_id", "order" },
                values: new object[,]
                {
                    { 1L, 1L, 1 },
                    { 2L, 2L, 1 }
                });

            migrationBuilder.InsertData(
                table: "participations",
                columns: new[] { "id", "book_id", "content_id", "person_id", "person_role_id" },
                values: new object[,]
                {
                    { 1L, null, 1L, 1L, 1L },
                    { 2L, null, 2L, 2L, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_bookmarks_book_id",
                table: "bookmarks",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "ix_bookmarks_user_id",
                table: "bookmarks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_country_id",
                table: "books",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_language_id",
                table: "books",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_publisher_id",
                table: "books",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_series_id",
                table: "books",
                column: "series_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_tag_id",
                table: "books",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_contents_content_id",
                table: "books_contents",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_selections_selections_id",
                table: "books_selections",
                column: "selections_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_shelves_shelves_id",
                table: "books_shelves",
                column: "shelves_id");

            migrationBuilder.CreateIndex(
                name: "ix_contents_country_id",
                table: "contents",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_contents_language_id",
                table: "contents",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_contents_themes_themes_id",
                table: "contents_themes",
                column: "themes_id");

            migrationBuilder.CreateIndex(
                name: "ix_participations_book_id",
                table: "participations",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "ix_participations_content_id",
                table: "participations",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "ix_participations_person_id",
                table: "participations",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_participations_person_role_id",
                table: "participations",
                column: "person_role_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_book_id",
                table: "reviews",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id",
                table: "reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_ratings_review_id",
                table: "reviews_ratings",
                column: "review_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_ratings_user_id",
                table: "reviews_ratings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_series_publisher_id",
                table: "series",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "ix_shelves_user_id",
                table: "shelves",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_tag_type_id",
                table: "tags",
                column: "tag_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_themes_parent_theme_id",
                table: "themes",
                column: "parent_theme_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "bookmarks");

            migrationBuilder.DropTable(
                name: "books_contents");

            migrationBuilder.DropTable(
                name: "books_selections");

            migrationBuilder.DropTable(
                name: "books_shelves");

            migrationBuilder.DropTable(
                name: "contents_themes");

            migrationBuilder.DropTable(
                name: "participations");

            migrationBuilder.DropTable(
                name: "reviews_ratings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "selections");

            migrationBuilder.DropTable(
                name: "shelves");

            migrationBuilder.DropTable(
                name: "themes");

            migrationBuilder.DropTable(
                name: "contents");

            migrationBuilder.DropTable(
                name: "person_roles");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "series");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropTable(
                name: "tag_types");
        }
    }
}
