using EFDataAccessLibary.DataAccess;
using EFDataAccessLibary.Models;
using EFDataAccessLibrary.DTOs;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AmazonaContext _context;
        public OrderRepository(AmazonaContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrdersOfUser(int userId)
        {
            return _context.orders
                .Where(order => order.userId == userId)
                .Include(order => order.orderItems)
                .Include(order => order.shippingAddress)
                .ToList();
        }

        public Order? GetOrder(int orderId)
        {
            return _context.orders
                .Include(order => order.orderItems)
                .Include(order => order.shippingAddress)
                .FirstOrDefault(x => x._id == orderId);
        }

        public Order SaveOrder(OrderInfo orderInfo)
        {
            var shippingAddress = new ShippingAddress
            {
                fullName = orderInfo.shippingAddress.fullName,
                address = orderInfo.shippingAddress.address,
                city = orderInfo.shippingAddress.city,
                postalCode = orderInfo.shippingAddress.postalCode,
                country = orderInfo.shippingAddress.country
            };
            List<OrderDetail> details = new List<OrderDetail>();
            for(int i = 0; i < orderInfo.orderItems.Count; i++)
            {
                //var product = new Product
                //{
                //    rating = orderInfo.orderItems[i].rating,
                //    numReviews = orderInfo.orderItems[i].numReviews,
                //    countInStock = orderInfo.orderItems[i].countInStock,
                //    _id = orderInfo.orderItems[i]._id,
                //    name = orderInfo.orderItems[i].name,
                //    slug = orderInfo.orderItems[i].slug,
                //    category = orderInfo.orderItems[i].category,
                //    image = orderInfo.orderItems[i].image,
                //    price = orderInfo.orderItems[i].price,
                //    brand = orderInfo.orderItems[i].brand,
                //    description = orderInfo.orderItems[i].description,
                //    createdAt = orderInfo.orderItems[i].createdAt,
                //    updatedAt = orderInfo.orderItems[i].updatedAt
                //};
                OrderDetail detail = new OrderDetail
                {
                    productId = orderInfo.orderItems[i]._id,
                    //product = product,
                    name = orderInfo.orderItems[i].name,
                    quantity = orderInfo.orderItems[i].quantity,
                    image = orderInfo.orderItems[i].image,
                    price = orderInfo.orderItems[i].price
                };
                details.Add(detail);
            }
            Order newOrder = new Order
            {
                userId = orderInfo.userId,
                orderItems = details,
                shippingAddress = shippingAddress,
                paymentMethod = orderInfo.paymentMethod,
                itemsPrice = orderInfo.itemsPrice,
                shippingPrice = orderInfo.shippingPrice,
                taxPrice = orderInfo.taxPrice,
                totalPrice = orderInfo.totalPrice
            };
            _context.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }
    }
}
