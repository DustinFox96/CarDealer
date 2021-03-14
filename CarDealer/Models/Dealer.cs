using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        [StringLength(30), Required]
        public string Code { get; set; }
        [StringLength(30), Required]
        public string City { get; set; }
        [StringLength(30), Required]
        public string State { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public int CarCount { get; set; }

        public Dealer() { }
        
    }
}
