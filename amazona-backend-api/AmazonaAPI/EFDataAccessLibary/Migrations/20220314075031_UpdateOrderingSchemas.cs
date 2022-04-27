using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class UpdateOrderingSchemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedAt",
                table: "orders",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "orders",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedAt",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "_id",
                keyValue: 1,
                column: "password",
                value: "$2a$13$.ZCIpQoJCW2zG7Bj9ocEQe2sqQzmDTMWR4dlBupTzN/AEIjkDSca2");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "_id",
                keyValue: 2,
                column: "password",
                value: "$2a$13$DsKq8zYxaRbNwOob5J1iWOPQTb8d3XwslUyB2VqOANiaFQZXkDur.");
        }
    }
}
