using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DTOs
{
    public class OrderItem
    {
        [Required]
        public float rating { get; set; }
        [Required]
        public int numReviews { get; set; }
        [Required]
        public int countInStock { get; set; }
        [Required]
        public int _id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string slug { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string image { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public string brand { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public DateTime? createdAt { get; set; }
        [Required]
        public DateTime? updatedAt { get; set; }
        [Required]
        public int quantity { get; set; }
    }
}
