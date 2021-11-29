using Core.Utilities.Result.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBasketService
    {
        IDataResult<List<BasketDetailDTO>> GetDetailsAll();
    }
}
