using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BasketDetailDTO:IDto
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStocks { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentType { get; set; }
        public string Description { get; set; }
    }
}
