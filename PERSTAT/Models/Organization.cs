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

        public string OrganizationName { get; set; }

        [Display(Name = "POC Primary")]
        public int PeopleId { get; set; }
        public ICollection<People> People { get; set; }
        public string OrganizationStreet1 { get; set; }

        public string OrgainzationStreet2 { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }
        public States State { get; set; }


    }
}
