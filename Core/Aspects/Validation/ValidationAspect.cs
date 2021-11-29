using Castle.DynamicProxy;
using Core.Cross_Cutting_Concers.Validation;
using Core.Utilities.Interceptors.AutoFac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Geçersiz Validator Tipi");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            IValidator validator = (IValidator)Activator.CreateInstance(_validatorType);
            Type entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var entities = invocation?.Arguments?.Where(x => x.GetType() == entityType);
            foreach (object entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }

        }
    }
}
