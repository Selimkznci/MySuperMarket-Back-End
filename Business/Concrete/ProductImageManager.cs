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
        IFileHelper _fileHelper;

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

            productImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);

            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(ProductImage productImage)
        {
            _fileHelper.Delete(productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<ProductImage> Get(int productImage)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == productImage));
        }

        public IDataResult<List<ProductImage>> GetAll()
        {

            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductImage>> GetImagesByProductId(int id)
        {
            return new SuccessDataResult<List<ProductImage>>(CheckIfProductImageNull(id));
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + productImage.ImagePath, PathConstants.ImagesPath);
            _productImageDal.Update(productImage);

            return new SuccessResult(Messages.ImageUpdated);
        }
        private IResult CheckImageLimitExceeded(int Id)
        {
            var productImageCount = _productImageDal.GetAll(p => p.ProductId == Id).Count;
            if (productImageCount >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
        private List<ProductImage> CheckIfProductImageNull(int id)
        {
            //Ürünün resmi yoksa default resim koyulması için yazdığımzı kod bloğu.
            string path = @"\Images\xx.jpg";
            var result = _productImageDal.GetAll(p => p.ProductId== id).Any();
            if (!result)
            {
                return new List<ProductImage> { new ProductImage{ ProductId= id, ImagePath = path, Date = DateTime.Now } };
            }
            return _productImageDal.GetAll(p => p.ProductId == id);
        }
    }
}
