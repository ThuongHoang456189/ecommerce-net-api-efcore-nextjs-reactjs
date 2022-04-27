using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibary.Models
{
    public class Product
    {
        [Required]
        public float rating { get; set; }
        [Required]
        public int numReviews { get; set; }
        [Required]
        public int countInStock { get; set; }
        [Key]
        public int _id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string name { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string slug { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string category { get; set; }
        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string image { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string brand { get; set; }
        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string description { get; set; }
        [Required]
        public DateTime? createdAt { get; set; }
        [Required]
        public DateTime? updatedAt { get; set; }
    }
}
