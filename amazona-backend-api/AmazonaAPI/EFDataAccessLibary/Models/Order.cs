using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Order
    {
        [Key]
        public int _id { get; set; }
        [Required]
        public int userId { get; set; }
        [JsonIgnore]
        public User user { get; set; }
        [InverseProperty("order")]
        public List<OrderDetail> orderItems { get; set; }
        [JsonIgnore]
        [Required]
        public int shippingAddressId { get; set; }
        [ForeignKey("shippingAddressId")]
        public ShippingAddress shippingAddress { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string paymentMethod { get; set; }
        //[Required]
        //public int paymentResultId { get; set; }
        //[ForeignKey("paymentResultId")]
        //public PaymentResult paymentResult { get; set; }
        [Required]
        public float itemsPrice { get; set; }
        [Required]
        public float shippingPrice { get; set; }
        [Required]
        public float taxPrice { get; set; }
        [Required]
        public float totalPrice { get; set; }
        [Required]
        public bool isPaid { get; set; }
        [Required]
        public bool isDelivered { get; set; }
        public DateTime? paidAt { get; set; }
        public DateTime? deliveredAt { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}
