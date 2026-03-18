using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "report_reasons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_report_reasons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "report_statuses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_report_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "report_target_types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_report_target_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    target_id = table.Column<long>(type: "bigint", nullable: false),
                    target_type_id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    status_id = table.Column<long>(type: "bigint", nullable: false),
                    reason_type_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    moderated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    moderated_by = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reports", x => x.id);
                    table.ForeignKey(
                        name: "fk_reports_report_reasons_reason_type_id",
                        column: x => x.reason_type_id,
                        principalTable: "report_reasons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_reports_report_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "report_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_reports_report_target_types_target_type_id",
                        column: x => x.target_type_id,
                        principalTable: "report_target_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "report_reasons",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Спам" },
                    { 2L, "Ненормативная лексика" },
                    { 3L, "Нарушение авторских прав" },
                    { 4L, "Терроризм и экстремизм" },
                    { 5L, "Иное" }
                });

            migrationBuilder.InsertData(
                table: "report_statuses",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Новое" },
                    { 2L, "В работе" },
                    { 3L, "Принято" },
                    { 4L, "отклонено" }
                });

            migrationBuilder.InsertData(
                table: "report_target_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Книги" },
                    { 2L, "Отзывы" },
                    { 3L, "Комментарии" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_reports_reason_type_id",
                table: "reports",
                column: "reason_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_reports_status_id",
                table: "reports",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_reports_target_type_id",
                table: "reports",
                column: "target_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "report_reasons");

            migrationBuilder.DropTable(
                name: "report_statuses");

            migrationBuilder.DropTable(
                name: "report_target_types");
        }
    }
}
