using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Assignment
    {
        [Key]
        [Required]
        public int AssignmentId { get; set; }
       
        [Display(Name ="Person")]
        public int PeopleId { get; set; }

        public People People { get; set; }

      
        [Display(Name ="Mission")]
        public int MissionId { get; set; }

        public Missions Mission { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        [Display(Name = "Incident")]
        public int IncidentId { get; set; } = 1;
        public Incident Incident { get; set; }

        [Display(Name="Location")]
        public int LocationId { get; set; }
        public Locations Location { get; set; }
    

    }
}
