using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.DateOfBirth == null)
            {
                return new ValidationResult("Date of Birth is required");
            }
            

            if(customer.Age >= 18 )
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("You must be 18 year or older to go on a paid plan");
            }
        }
    }
}