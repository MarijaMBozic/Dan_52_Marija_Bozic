using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastryShop.Models
{
    public class CakeByOrder
    {
        public int  CakeId { get; set; }
        public string CakeName { get; set; }
        public double CakePrice { get; set; }
        public int CakeQuantity { get; set; }
        public string CakeComment { get; set; } = string.Empty;
        public double TotalPriceByCake { get; set; }
    }
}
