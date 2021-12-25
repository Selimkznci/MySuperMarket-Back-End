using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {        
            IDataResult<List<ProductImage>> GetAll();
            IResult Add(IFormFile file, ProductImage productImage);
            IResult Update(IFormFile file, ProductImage productImage);
            IResult Delete(ProductImage productImage);
            IDataResult<ProductImage> Get(int producdId);
            IDataResult<List<ProductImage>> GetImagesByProductId(int id); 
    }
}
