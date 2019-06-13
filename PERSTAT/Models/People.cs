using PERSTAT.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class People
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name ="First")]
        public string NameFirst { get; set; }

        [Display(Name ="Middle")]
        public string NameMiddle { get; set; }
        [Display(Name ="Last")]
        public string NameLast { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }


        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public ICollection<Assignment> Assignments { get; set; }



    }

}
