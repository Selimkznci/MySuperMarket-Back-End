using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SuperMarketContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (SuperMarketContext context = new SuperMarketContext())
            {
                var result = from op in context.OperationClaims
                             join uop in context.UserOperationClaims
                             on op.Id equals uop.OperationClaimId
                             where uop.UserId == user.UserId
                             select new OperationClaim { Id = op.Id, Name = op.Name };
                return result.ToList();
            }
        }
    }
}
