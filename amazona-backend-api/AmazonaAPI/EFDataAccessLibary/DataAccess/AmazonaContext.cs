using EFDataAccessLibary.Models;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibary.DataAccess
{
    public class AmazonaContext : DbContext
    {
        public AmazonaContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<ShippingAddress> shippingAddresses { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("products");
            modelBuilder.Entity<Product>()
                .Property(product => product.rating)
                .HasDefaultValue(0);
            modelBuilder.Entity<Product>()
                .Property(product => product.numReviews)
                .HasDefaultValue(0);
            modelBuilder.Entity<Product>()
                .Property(product => product.countInStock)
                .HasDefaultValue(0);
            modelBuilder.Entity<Product>()
                .Property(product => product._id);
            modelBuilder.Entity<Product>()
                .Property(product => product.name);
            modelBuilder.Entity<Product>()
                .Property(product => product.slug);
            modelBuilder.Entity<Product>()
                .Property(product => product.category);
            modelBuilder.Entity<Product>()
                .Property(product => product.image);
            modelBuilder.Entity<Product>()
                .Property(product => product.price);
            modelBuilder.Entity<Product>()
                .Property(product => product.brand);
            modelBuilder.Entity<Product>()
                .Property(product => product.description);
            modelBuilder.Entity<Product>()
                .Property(product => product.createdAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Product>()
                .Property(product => product.updatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        rating = 4.5f,
                        numReviews = 10,
                        countInStock = 20,
                        _id = 1,
                        name = "Free Shirt",
                        slug = "free-shirt",
                        category = "Shirts",
                        image = "/images/shirt1.jpg",
                        price = 70,
                        brand = "Nike",
                        description = "A popular shirt",
                        createdAt = null,
                        updatedAt = null
                    },
                    new Product
                    {
                        rating = 4.2f,
                        numReviews = 10,
                        countInStock = 20,
                        _id = 2,
                        name = "Fit Shirt",
                        slug = "fit-shirt",
                        category = "Shirts",
                        image = "/images/shirt2.jpg",
                        price = 80,
                        brand = "Adidas",
                        description = "A popular shirt",
                        createdAt = null,
                        updatedAt = null
                    },
                    new Product
                    {
                        rating = 4.5f,
                        numReviews = 10,
                        countInStock = 20,
                        _id = 3,
                        name = "Slim Shirt",
                        slug = "slim-shirt",
                        category = "Shirts",
                        image = "/images/shirt3.jpg",
                        price = 90,
                        brand = "Raymond",
                        description = "A popular shirt",
                        createdAt = null,
                        updatedAt = null
                    },
                    new Product
                    {
                        rating = 4.5f,
                        numReviews = 10,
                        countInStock = 20,
                        _id = 4,
                        name = "Golf Pants",
                        slug = "golf-pants",
                        category = "Pants",
                        image = "/images/pants1.jpg",
                        price = 90,
                        brand = "Oliver",
                        description = "Smart looking pants",
                        createdAt = null,
                        updatedAt = null
                    },
                    new Product
                    {
                        rating = 4.5f,
                        numReviews = 10,
                        countInStock = 20,
                        _id = 5,
                        name = "Fit Pants",
                        slug = "fit-pants",
                        category = "Pants",
                        image = "/images/pants2.jpg",
                        price = 95,
                        brand = "Zara",
                        description = "A popular pants",
                        createdAt = null,
                        updatedAt = null
                    },
                    new Product
                    {
                        rating = 4.5f,
                        numReviews = 10,
                        countInStock = 20,
                        _id = 6,
                        name = "Classic Pants",
                        slug = "classic-pants",
                        category = "Pants",
                        image = "/images/pants3.jpg",
                        price = 75,
                        brand = "Casely",
                        description = "A popular pants",
                        createdAt = null,
                        updatedAt = null
                    }
                );

            modelBuilder.Entity<User>()
               .ToTable("users");
            modelBuilder.Entity<User>()
                .Property(user => user._id);
            modelBuilder.Entity<User>()
                .Property(user => user.name);
            modelBuilder.Entity<User>()
                .Property(user => user.email);
            modelBuilder.Entity<User>()
                .Property(user => user.password);
            modelBuilder.Entity<User>()
                .Property(user => user.isAdmin)
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
                .Property(user => user.createdAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>()
                .Property(user => user.updatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        _id = 1,
                        name = "John",
                        email = "admin@example.com",
                        password = BCrypt.Net.BCrypt.HashPassword("123456", BCrypt.Net.BCrypt.GenerateSalt(13)),
                        isAdmin = true,
                        createdAt = null,
                        updatedAt = null
                    },
                    new User
                    {
                        _id = 2,
                        name = "Jane",
                        email = "user@example.com",
                        password = BCrypt.Net.BCrypt.HashPassword("123456", BCrypt.Net.BCrypt.GenerateSalt(13)),
                        isAdmin = false,
                        createdAt = null,
                        updatedAt = null
                    }
                );

            modelBuilder.Entity<ShippingAddress>()
               .ToTable("shippingAddresses");
            modelBuilder.Entity<ShippingAddress>()
                .Property(shippingAddress => shippingAddress._id);
            modelBuilder.Entity<ShippingAddress>()
                .Property(shippingAddress => shippingAddress.fullName);
            modelBuilder.Entity<ShippingAddress>()
                .Property(shippingAddress => shippingAddress.address);
            modelBuilder.Entity<ShippingAddress>()
                .Property(shippingAddress => shippingAddress.city);
            modelBuilder.Entity<ShippingAddress>()
                .Property(shippingAddress => shippingAddress.postalCode);
            modelBuilder.Entity<ShippingAddress>()
                .Property(shippingAddress => shippingAddress.country);

            modelBuilder.Entity<Order>()
               .ToTable("orders");
            modelBuilder.Entity<Order>()
                .Property(order => order._id);
            modelBuilder.Entity<Order>()
                .Property(order => order.userId);
            modelBuilder.Entity<Order>()
                .Property(order => order.shippingAddressId);
            modelBuilder.Entity<Order>()
                .Property(order => order.paymentMethod);
            //modelBuilder.Entity<Order>()
            //    .Property(order => order.paymentResultId);
            modelBuilder.Entity<Order>()
                .Property(order => order.itemsPrice);
            modelBuilder.Entity<Order>()
                .Property(order => order.shippingPrice);
            modelBuilder.Entity<Order>()
                .Property(order => order.taxPrice);
            modelBuilder.Entity<Order>()
                .Property(order => order.totalPrice);
            modelBuilder.Entity<Order>()
                .Property(order => order.isPaid)
                .HasDefaultValue(false);
            modelBuilder.Entity<Order>()
                .Property(order => order.isDelivered)
                .HasDefaultValue(false);
            modelBuilder.Entity<Order>()
                .Property(order => order.paidAt);
            modelBuilder.Entity<Order>()
                .Property(order => order.deliveredAt);
            modelBuilder.Entity<Order>()
                .Property(order => order.createdAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Order>()
                .Property(order => order.updatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<OrderDetail>()
               .ToTable("ordersDetails");
            modelBuilder.Entity<OrderDetail>()
                .Property(orderDetail => orderDetail._id);
            modelBuilder.Entity<OrderDetail>()
                .Property(orderDetail => orderDetail.productId);
            modelBuilder.Entity<OrderDetail>()
                .Property(orderDetail => orderDetail.orderId);
            modelBuilder.Entity<OrderDetail>()
                .Property(orderDetail => orderDetail.name);
            modelBuilder.Entity<OrderDetail>()
                .Property(orderDetail => orderDetail.quantity);
            modelBuilder.Entity<OrderDetail>()
                .Property(orderDetail => orderDetail.image);
            modelBuilder.Entity<OrderDetail>()
                .Property(orderDetail => orderDetail.price);
        }
    }
}
