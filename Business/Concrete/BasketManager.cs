using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        ISaleDal _saleDal;

        public BasketManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        public IDataResult<List<BasketDetailDTO>> GetDetailsAll()
        {
            return new SuccessDataResult<List<BasketDetailDTO>>(_saleDal.GetBasketDetailDTOs(),Messages.ProductListed);
        }
    }
}
