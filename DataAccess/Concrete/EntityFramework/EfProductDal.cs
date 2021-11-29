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
    public class EfProductDal : EfEntityRepositoryBase<Product, SuperMarketContext>, IProductDal
    {
        public List<ProductDetailDTO> GetProductDetail()
        {
            using (SuperMarketContext context = new SuperMarketContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDTO
                             {
                                 productId = p.ProductId,
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStocks = p.UnitsInStocks
                             };
                return result.ToList();
            }
        }
    }
}
