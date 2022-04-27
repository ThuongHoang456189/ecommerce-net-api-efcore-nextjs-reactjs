using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class InitializeOrderingSchemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shippingAddresses",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    postalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippingAddresses", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    shippingAddressId = table.Column<int>(type: "int", nullable: false),
                    paymentMethod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    itemsPrice = table.Column<float>(type: "real", nullable: false),
                    shippingPrice = table.Column<float>(type: "real", nullable: false),
                    taxPrice = table.Column<float>(type: "real", nullable: false),
                    totalPrice = table.Column<float>(type: "real", nullable: false),
                    isPaid = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    isDelivered = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    paidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deliveredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x._id);
                    table.ForeignKey(
                        name: "FK_orders_shippingAddresses_shippingAddressId",
                        column: x => x.shippingAddressId,
                        principalTable: "shippingAddresses",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordersDetails",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersDetails", x => x._id);
                    table.ForeignKey(
                        name: "FK_ordersDetails_orders_orderId",
                        column: x => x.orderId,
                        principalTable: "orders",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordersDetails_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_orders_shippingAddressId",
                table: "orders",
                column: "shippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_userId",
                table: "orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersDetails_orderId",
                table: "ordersDetails",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersDetails_productId",
                table: "ordersDetails",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ordersDetails");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "shippingAddresses");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "_id",
                keyValue: 1,
                column: "password",
                value: "$2a$13$Pp0.oBDEhN6dCjMYpsTy/e2oERkC4v6Nd2aHHi6Q7G5Mi6Rp.TDGK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "_id",
                keyValue: 2,
                column: "password",
                value: "$2a$13$dlhvWFO/2vU2AJqwIjeyau4fnFRzQnDYXkmyLAVlGSo3Yo5IV.F6O");
        }
    }
}
