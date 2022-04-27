using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DTOs
{
    public class ShippingAddressInfo
    {
        [Required]
        public string fullName { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string postalCode { get; set; }
        [Required]
        public string country { get; set; }
    }
}
