using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vinly.Models
{
    public class Min18YersIfMember : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown|| customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDay== null)
                return new ValidationResult("Birth day is required");

            var AGE = DateTime.Today.Year - customer.BirthDay.Value.Year;
                return (AGE >= 18) ? ValidationResult.Success :
                        new ValidationResult("Customer need to be atleast 18 years old");
        }
    }
}