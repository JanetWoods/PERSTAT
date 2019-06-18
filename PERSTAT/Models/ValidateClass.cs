using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class ValidateClass : ValidationAttribute
    {

        public bool GoodDate(DateTime dateStart, DateTime dateEnd)
        {
            return (dateEnd > dateStart);
        }

    }
}        

