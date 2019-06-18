using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class ValidateDateRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime DateEnd = (DateTime)value;
            DateTime DateStart = (DateTime)value;
            if(DateStart < DateEnd)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The End date must be AFTER the start date.");
            }
        }

          
    }
}
