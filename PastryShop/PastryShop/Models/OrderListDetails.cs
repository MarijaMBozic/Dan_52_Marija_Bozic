using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastryShop.Models
{
    public class OrderListDetails
    {
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public int NumberOfcaker { get; set; }
        public string ListOfCake { get; set; }
        public string Comment { get; set; }
    }
}
