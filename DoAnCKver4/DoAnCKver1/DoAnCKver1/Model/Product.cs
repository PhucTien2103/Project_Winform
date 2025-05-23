using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCKver1.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
    }
}
