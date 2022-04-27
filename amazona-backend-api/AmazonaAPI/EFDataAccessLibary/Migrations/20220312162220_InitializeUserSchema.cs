using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class InitializeUserSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "products",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "products",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.email);
                });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "_id",
                keyValue: 2,
                column: "image",
                value: "/images/shirt2.jpg");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "email", "isAdmin", "name", "password" },
                values: new object[] { "admin@example.com", true, "John", "$2a$13$WiT24zXs6hfdLLumKanjke/DjAVYW/NtvPQSN1N.WhZk1RAapTRoW" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "email", "name", "password" },
                values: new object[] { "user@example.com", "Jane", "$2a$13$0duGmL2MLpsBb1hidES43um1KvCndZNLHnFUC1t6NLeZRgYnesfv2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "products",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "products",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "_id",
                keyValue: 2,
                column: "image",
                value: "/images/banner2.jpg");
        }
    }
}
