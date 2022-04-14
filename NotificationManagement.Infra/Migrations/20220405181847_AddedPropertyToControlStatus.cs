using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationManagement.Infra.Migrations
{
    public partial class AddedPropertyToControlStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WasSent",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 15, 18, 46, 811, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 15, 18, 46, 813, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 15, 18, 46, 813, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 15, 18, 46, 813, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 15, 18, 46, 813, DateTimeKind.Local).AddTicks(2688));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WasSent",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 8, 55, 27, 531, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7676));
        }
    }
}
