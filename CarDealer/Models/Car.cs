using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class Car
    {
        public int Id { get; set; }
        [StringLength(17), Required]
        public string Vin { get; set; }
        [StringLength(30), Required]
        public string Make { get; set; }
        [StringLength(30), Required]
        public string Model { get; set; }
        [StringLength(12), Required]
        public string Trim { get; set; }
        public int Year { get; set; }
        [StringLength(12), Required]
        public string Status { get; set; }
        [Column(TypeName = "decimal (11,2)")]
        public decimal Cost { get; set; }
        [Column(TypeName = "decimal (11,2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal (11,2)")]
        public decimal Profit { get; set; }
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

         

        public Car() { }
   
  
    }
}
