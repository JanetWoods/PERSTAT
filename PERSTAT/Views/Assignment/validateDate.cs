using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class DateGreaterThan: ValidationAttribute
    {
        private string _startDatePropertyName;
        public DateGreaterThan(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_startDatePropertyName);
            var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);

            if((DateTime)value > (DateTime)propertyValue)
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
