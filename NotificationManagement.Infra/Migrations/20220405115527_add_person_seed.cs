using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationManagement.Infra.Migrations
{
    public partial class add_person_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "CreateDate", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 5, 8, 55, 27, 531, DateTimeKind.Local).AddTicks(147), "joao@devscope.net", "João", "12345678" },
                    { 2, new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7609), "pedro@devscope.net", "Pedro", "23456789" },
                    { 3, new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7666), "marcos@devscope.net", "Marcos", "34567890" },
                    { 4, new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7672), "carlos@devscope.net", "Carlos", "45678901" },
                    { 5, new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7676), "emanuel@devscope.net", "Emanuel", "56789012" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
