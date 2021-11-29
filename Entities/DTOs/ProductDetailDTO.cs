using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDTO:IDto
    {
        public int productId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStocks { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
