using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class UpdatingOrderSchemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "paidAt",
                table: "orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deliveredAt",
                table: "orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "_id",
                keyValue: 1,
                column: "password",
                value: "$2a$13$ttXzNqSMImUWGZp4E5h15u9M.hULLd9Z25JwYiTHvyQzB4V2zvNm.");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "_id",
                keyValue: 2,
                column: "password",
                value: "$2a$13$Qzq4ggKdTXcaoV8SmFSktuIGpZP7Qwi00zv68LJ83hma8T8Csu7Ve");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "paidAt",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deliveredAt",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "_id",
                keyValue: 1,
                column: "password",
                value: "$2a$13$aCPw2lV6nJRgw6XIU.7Ekeh3yGbGrg/0FSJARDZAqpIPOh6ui/eFq");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "_id",
                keyValue: 2,
                column: "password",
                value: "$2a$13$mH6jOq3sywMgRMBmXjIYGOdA0lvYvIa5Gez2uAgspE2y6NWV59e0e");
        }
    }
}
