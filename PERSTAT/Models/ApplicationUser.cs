using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        [Required]
        [Display(Name="First name")]
        public string NameFirst { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string NameLast { get; set; }

        [Display(Name ="Middle name")]
        public string NameMiddle { get; set; }
        
    }
}
