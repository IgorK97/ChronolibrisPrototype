using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chronolibris.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_moderation_task_report_statuses_status_id",
                table: "moderation_task");

            migrationBuilder.DropForeignKey(
                name: "fk_reports_moderation_task_moderation_task_id",
                table: "reports");

            migrationBuilder.DropPrimaryKey(
                name: "pk_moderation_task",
                table: "moderation_task");

            migrationBuilder.RenameTable(
                name: "moderation_task",
                newName: "moderation_tasks");

            migrationBuilder.RenameIndex(
                name: "ix_moderation_task_status_id",
                table: "moderation_tasks",
                newName: "ix_moderation_tasks_status_id");

            migrationBuilder.AlterColumn<long>(
                name: "moderation_task_id",
                table: "reports",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "resolved_at",
                table: "moderation_tasks",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "moderation_tasks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "reason_type_id",
                table: "moderation_tasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "pk_moderation_tasks",
                table: "moderation_tasks",
                column: "id");

            migrationBuilder.UpdateData(
                table: "report_statuses",
                keyColumn: "id",
                keyValue: 4L,
                column: "name",
                value: "Отклонено");

            migrationBuilder.CreateIndex(
                name: "ix_moderation_tasks_reason_type_id",
                table: "moderation_tasks",
                column: "reason_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_moderation_tasks_report_reasons_reason_type_id",
                table: "moderation_tasks",
                column: "reason_type_id",
                principalTable: "report_reasons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_moderation_tasks_report_statuses_status_id",
                table: "moderation_tasks",
                column: "status_id",
                principalTable: "report_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_reports_moderation_tasks_moderation_task_id",
                table: "reports",
                column: "moderation_task_id",
                principalTable: "moderation_tasks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_moderation_tasks_report_reasons_reason_type_id",
                table: "moderation_tasks");

            migrationBuilder.DropForeignKey(
                name: "fk_moderation_tasks_report_statuses_status_id",
                table: "moderation_tasks");

            migrationBuilder.DropForeignKey(
                name: "fk_reports_moderation_tasks_moderation_task_id",
                table: "reports");

            migrationBuilder.DropPrimaryKey(
                name: "pk_moderation_tasks",
                table: "moderation_tasks");

            migrationBuilder.DropIndex(
                name: "ix_moderation_tasks_reason_type_id",
                table: "moderation_tasks");

            migrationBuilder.DropColumn(
                name: "reason_type_id",
                table: "moderation_tasks");

            migrationBuilder.RenameTable(
                name: "moderation_tasks",
                newName: "moderation_task");

            migrationBuilder.RenameIndex(
                name: "ix_moderation_tasks_status_id",
                table: "moderation_task",
                newName: "ix_moderation_task_status_id");

            migrationBuilder.AlterColumn<long>(
                name: "moderation_task_id",
                table: "reports",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "resolved_at",
                table: "moderation_task",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "moderation_task",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_moderation_task",
                table: "moderation_task",
                column: "id");

            migrationBuilder.UpdateData(
                table: "report_statuses",
                keyColumn: "id",
                keyValue: 4L,
                column: "name",
                value: "отклонено");

            migrationBuilder.AddForeignKey(
                name: "fk_moderation_task_report_statuses_status_id",
                table: "moderation_task",
                column: "status_id",
                principalTable: "report_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_reports_moderation_task_moderation_task_id",
                table: "reports",
                column: "moderation_task_id",
                principalTable: "moderation_task",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
