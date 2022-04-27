using EFDataAccessLibrary.DTOs;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public interface IOrderRepository
    {
        Order SaveOrder(OrderInfo orderInfo);
        Order? GetOrder(int orderId);
        List<Order> GetAllOrdersOfUser(int userId);
    }
}
