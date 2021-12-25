using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {

            IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.ProductId));
            if (result != null)
            {
                return result;
            }
            var result2 = FileHelper.Add(file);
            if (!result2.Success)
            {
                return new ErrorResult(result2.Message);
            }
            var deneme = productImage.ImagePath;
            productImage.ImagePath = result2.Message;
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }


        public IResult Delete(ProductImage productImage)
        {
            FileHelper.Delete(productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult();
        }
        public IDataResult<List<ProductImage>> GetAll()
        {

            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<ProductImage> Get(int productImageId)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == productImageId));
        }


        public IResult Update(IFormFile file, ProductImage productImage)
        {
            var isImage = _productImageDal.Get(c => c.Id == productImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            productImage.ImagePath = updatedFile.Message;
            productImage.Date = DateTime.Now;
            _productImageDal.Update(productImage);
            return new SuccessResult();
        }
        private IResult CheckImageLimitExceeded(int productId)
        {
            var carImageCount = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
        private List<ProductImage> CheckIfProductImageNull(int id)
        {
            //Product  resmi yoksa default resim koyulması için yazdığımzı kod bloğu.
            string path = @"\Uploads\Images\Default.png";
            var result = _productImageDal.GetAll(c => c.ProductId == id).Any();
            if (!result)
            {
                return new List<ProductImage> { new ProductImage { ProductId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _productImageDal.GetAll(p => p.ProductId == id);
        }

        public IDataResult<List<ProductImage>> GetImagesByProductId(int id)
        {
            return new SuccessDataResult<List<ProductImage>>(CheckIfProductImageNull(id));
        }
    }
}
