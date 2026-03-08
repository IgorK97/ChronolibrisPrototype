using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedThemes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_themes_themes_parent_theme_id",
                table: "themes");

            migrationBuilder.UpdateData(
                table: "themes",
                keyColumn: "id",
                keyValue: 1L,
                column: "name",
                value: "История");

            migrationBuilder.UpdateData(
                table: "themes",
                keyColumn: "id",
                keyValue: 2L,
                column: "name",
                value: "Археология");

            migrationBuilder.UpdateData(
                table: "themes",
                keyColumn: "id",
                keyValue: 3L,
                column: "name",
                value: "Философия");

            migrationBuilder.UpdateData(
                table: "themes",
                keyColumn: "id",
                keyValue: 4L,
                column: "name",
                value: "Религия");

            migrationBuilder.InsertData(
                table: "themes",
                columns: new[] { "id", "name", "parent_theme_id" },
                values: new object[,]
                {
                    { 5L, "Всеобщая и мировая история", 1L },
                    { 6L, "Региональная и национальная история", 1L },
                    { 14L, "История от древнейших времен до сегодняшнего дня", 1L },
                    { 20L, "История: отдельные темы и события", 1L },
                    { 21L, "Военная история", 1L },
                    { 26L, "История западной философии", 3L },
                    { 31L, "Восточная философия", 3L },
                    { 32L, "Исламская и арабская философия", 3L },
                    { 33L, "Социальная и политическая философия", 3L },
                    { 34L, "Христианство", 4L },
                    { 35L, "Буддизм", 4L },
                    { 36L, "Ислам", 4L },
                    { 7L, "История Европы", 6L },
                    { 9L, "История Азии", 6L },
                    { 10L, "История Африки", 6L },
                    { 11L, "История Америки", 6L },
                    { 12L, "История Австралазии и Тихоокеании", 6L },
                    { 13L, "История других земель", 6L },
                    { 15L, "История Древнего мира", 14L },
                    { 16L, "История Средневековья", 14L },
                    { 17L, "История Нового времени", 14L },
                    { 18L, "История 20 века", 14L },
                    { 19L, "История 21 века", 14L },
                    { 22L, "Гражданская война в России", 21L },
                    { 23L, "Первая мировая война", 21L },
                    { 24L, "Вторая мировая война", 21L },
                    { 25L, "Крымская война", 21L },
                    { 27L, "Античная философия", 26L },
                    { 28L, "Философия Средних веков и эпохи Ренессанса", 26L },
                    { 29L, "Философия эпохи Нового времени", 26L },
                    { 30L, "Современная философия", 26L },
                    { 8L, "История России", 7L }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_themes_themes_parent_theme_id",
                table: "themes",
                column: "parent_theme_id",
                principalTable: "themes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_themes_themes_parent_theme_id",
                table: "themes");

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "themes",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.UpdateData(
                table: "themes",
                keyColumn: "id",
                keyValue: 1L,
                column: "name",
                value: "Отечественная история");

            migrationBuilder.UpdateData(
                table: "themes",
                keyColumn: "id",
                keyValue: 2L,
                column: "name",
                value: "История религии");

            migrationBuilder.UpdateData(
                table: "themes",
                keyColumn: "id",
                keyValue: 3L,
                column: "name",
                value: "История культуры");

            migrationBuilder.UpdateData(
                table: "themes",
                keyColumn: "id",
                keyValue: 4L,
                column: "name",
                value: "Социально-экономическая история");

            migrationBuilder.AddForeignKey(
                name: "fk_themes_themes_parent_theme_id",
                table: "themes",
                column: "parent_theme_id",
                principalTable: "themes",
                principalColumn: "id");
        }
    }
}
