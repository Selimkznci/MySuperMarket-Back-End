using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSaleDal : EfEntityRepositoryBase<Sale, SuperMarketContext>, ISaleDal
    {
        public List<BasketDetailDTO> GetBasketDetailDTOs()
        {
            using (SuperMarketContext context = new SuperMarketContext())
            {
                var result = from s in context.Sales
                             join p in context.Products
                             on s.ProductId equals p.ProductId
                             select new BasketDetailDTO
                             {
                                 SaleId = s.SaleId,
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStocks = p.UnitsInStocks,
                                 TotalAmount = s.TotalAmount,
                                 PaymentType = s.PaymentType,
                                 Description = s.Description

                             };
                return result.ToList();
            }
        }
    }
}
