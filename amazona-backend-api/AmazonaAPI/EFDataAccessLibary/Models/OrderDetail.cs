using EFDataAccessLibary.Models;
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
    public class OrderDetail
    {
        [Key]
        public int _id { get; set; }
        [Required]
        public int productId { get; set; }
        [JsonIgnore]
        [ForeignKey("productId")]
        public Product product { get; set; }
        [JsonIgnore]
        [Required]
        public int orderId { get; set; }
        [JsonIgnore]
        [ForeignKey("orderId")]
        public Order order { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string name { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string image { get; set; }
        [Required]
        public float price { get; set; }
    }
}
