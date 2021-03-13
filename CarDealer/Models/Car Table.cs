using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Car_Table
    {
        public int Id { get; set; }
         public virtual Dealer_table Dealer_Table { get; set; }
        public int DealerId { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Profit { get; set; }
    }
}
