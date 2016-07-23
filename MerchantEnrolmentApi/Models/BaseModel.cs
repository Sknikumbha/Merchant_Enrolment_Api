using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MerchantEnrolmentApi.Models
{
    public abstract class BaseModel<T> : IValidatableObject
        where T : IValidator, new()
    {
        public IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            var validator = new T();
            var result = validator.Validate(this);

            return result.Errors.Select(item=>new ValidationResult(item.ErrorMessage,new [] {item.PropertyName}));
        }
    }
}