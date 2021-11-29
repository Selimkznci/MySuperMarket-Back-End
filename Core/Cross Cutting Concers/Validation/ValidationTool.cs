using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cross_Cutting_Concers.Validation
{
    public class ValidationTool
    {
        public static void Validate<T>(IValidator validator, T entity)
        {
            ValidationContext<T> validationContext = new ValidationContext<T>(entity);
            var result = validator.Validate(validationContext);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
