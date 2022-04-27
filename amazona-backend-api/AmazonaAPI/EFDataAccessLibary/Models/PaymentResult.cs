using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class PaymentResult
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string status { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string email_address { get; set; }
    }
}
