using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Sale:IEntity
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentType { get; set; }
        public string Description { get; set; }
    }
}
