using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SaleManager : ISaleService
    {
        ISaleDal _saleDal;
        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }
        [ValidationAspect(typeof(SaleValidator))]
        public IResult Add(Sale sale)
        {
            _saleDal.Add(sale);
            return new SuccessResult(Messages.SaleAdded);
        }

        public IResult Delete(Sale sale)
        {
            _saleDal.Delete(sale);
            return new SuccessResult(Messages.SaleDeleted);
        }
        
        public IDataResult<List<Sale>> GetAll()
        {
            return new SuccessDataResult<List<Sale>>(_saleDal.GetAll(),Messages.SaleListed);
        }

        //public IDataResult<List<BasketDetailDTO>> GetDetailsAll()
        //{
        //    return new SuccessDataResult<List<BasketDetailDTO>>(_saleDal.GetBasketDetailDTOs());
        //}

        public IResult Update(Sale sale)
        {
            _saleDal.Update(sale);
            return new SuccessResult(Messages.SaleUptaded);
        }
    }
}
