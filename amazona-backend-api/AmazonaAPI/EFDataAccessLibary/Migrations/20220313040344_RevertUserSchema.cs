using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class RevertUserSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "email",
                keyValue: "admin@example.com");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "email",
                keyValue: "user@example.com");

            migrationBuilder.AddColumn<int>(
                name: "_id",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "_id");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "_id", "email", "isAdmin", "name", "password" },
                values: new object[] { 1, "admin@example.com", true, "John", "$2a$13$Pp0.oBDEhN6dCjMYpsTy/e2oERkC4v6Nd2aHHi6Q7G5Mi6Rp.TDGK" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "_id", "email", "name", "password" },
                values: new object[] { 2, "user@example.com", "Jane", "$2a$13$dlhvWFO/2vU2AJqwIjeyau4fnFRzQnDYXkmyLAVlGSo3Yo5IV.F6O" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropColumn(
                name: "_id",
                table: "users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "email");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "email",
                keyValue: "admin@example.com",
                column: "password",
                value: "$2a$13$WiT24zXs6hfdLLumKanjke/DjAVYW/NtvPQSN1N.WhZk1RAapTRoW");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "email",
                keyValue: "user@example.com",
                column: "password",
                value: "$2a$13$0duGmL2MLpsBb1hidES43um1KvCndZNLHnFUC1t6NLeZRgYnesfv2");
        }
    }
}
