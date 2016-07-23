using FluentValidation;
using MerchantEnrolmentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantEnrolmentApi.Validator
{
    public class MerchantEnrolmentValidator : AbstractValidator<MerchantEnrolmentModel>
    {
        public MerchantEnrolmentValidator()
        {
            RuleFor(m => m.MerchantName).Length(0, 100);
            RuleFor(m => m.CreatedBy).Length(0, 50);
            RuleFor(m => m.NumberOfOutlets).GreaterThanOrEqualTo(10);
        }
    }
}