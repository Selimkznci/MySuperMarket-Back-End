using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISaleService
    {
      //  IDataResult<List<BasketDetailDTO>> GetDetailsAll();
        IDataResult<List<Sale>> GetAll();
        IResult Add(Sale sale);
        IResult Update(Sale sale);
        IResult Delete(Sale sale);
    }
}
