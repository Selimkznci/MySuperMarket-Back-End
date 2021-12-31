using Core.Utilities.Interceptors.AutoFac;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;//Nuget'den paket indirildi
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constans;

namespace Business.BusinessAspects.Autofac
{
    //Yetki Kontrolü    JTW İçin 
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;  //her İstek için httpcontexti oluştur 

        public SecuredOperation(string roles)//Rolleri ver
        {
            _roles = roles.Split(',');  // dmeek metni benim belirittiğim karaktere göre arraye atıyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); 
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))// claimlerin içinde ilgili rol var ise
                {
                    return; // return et
                }
            }
            throw new Exception(Messages.AuthorizationDenied);//Yoksa eğer senin yetkin yok hatası ver
        }
    }
}
