using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class InitializeProductSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    numReviews = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    countInStock = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    slug = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    image = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    brand = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x._id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "_id", "brand", "category", "countInStock", "description", "image", "name", "numReviews", "price", "rating", "slug" },
                values: new object[,]
                {
                    { 1, "Nike", "Shirts", 20, "A popular shirt", "/images/shirt1.jpg", "Free Shirt", 10, 70f, 4.5f, "free-shirt" },
                    { 2, "Adidas", "Shirts", 20, "A popular shirt", "/images/banner2.jpg", "Fit Shirt", 10, 80f, 4.2f, "fit-shirt" },
                    { 3, "Raymond", "Shirts", 20, "A popular shirt", "/images/shirt3.jpg", "Slim Shirt", 10, 90f, 4.5f, "slim-shirt" },
                    { 4, "Oliver", "Pants", 20, "Smart looking pants", "/images/pants1.jpg", "Golf Pants", 10, 90f, 4.5f, "golf-pants" },
                    { 5, "Zara", "Pants", 20, "A popular pants", "/images/pants2.jpg", "Fit Pants", 10, 95f, 4.5f, "fit-pants" },
                    { 6, "Casely", "Pants", 20, "A popular pants", "/images/pants3.jpg", "Classic Pants", 10, 75f, 4.5f, "classic-pants" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
