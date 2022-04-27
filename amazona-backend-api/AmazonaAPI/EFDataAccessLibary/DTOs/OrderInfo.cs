using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DTOs
{
    public class OrderInfo
    {
        [Required]
        public int userId { set; get; }
        [Required]
        public List<OrderItem> orderItems { set; get; }
        [Required]
        public ShippingAddressInfo shippingAddress { set; get; }
        [Required]
        public string paymentMethod { get; set; }
        [Required]
        public float itemsPrice { get; set; }
        [Required]
        public float shippingPrice { get; set; }
        [Required]
        public float taxPrice { get; set; }
        [Required]
        public float totalPrice { get; set; }
    }
}
