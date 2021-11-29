using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors.AutoFac
{
    public class AspectInterceptionSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            List<MethodInterceptionBaseAttribute> classAttributes =
                type?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            List<Type> parametersType = new List<Type>();
            method.GetParameters().ToList().ForEach(x => parametersType.Add(x.ParameterType));

            var methodAttributes = type.GetMethod(method.Name, parametersType.ToArray()).GetCustomAttributes<MethodInterceptionBaseAttribute>();
            classAttributes?.AddRange(methodAttributes);


            return classAttributes?.OrderByDescending(x => x.Priority).ToArray();
        }
    }
}
