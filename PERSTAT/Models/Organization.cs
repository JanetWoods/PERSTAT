using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Organization
    {
        [Key]
        [Required]
        public int OrganizationId { get; set; }
        [Display(Name="Organization")]
        public string OrganizationName { get; set; }
        [Display(Name="Address")]
        public string OrganizationStreet1 { get; set; }

        [Display(Name = "Address")]
        public string OrganizationStreet2 { get; set; }

        public string City { get; set; }
        [Display(Name="State")]
        public int StateId { get; set; }

        [Display(Name = "State")]
        public States State { get; set; }

        public ICollection<People> People { get; set; }


    }
}
