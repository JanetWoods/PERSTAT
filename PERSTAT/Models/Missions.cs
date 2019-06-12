using PERSTAT.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Missions
    {
      
        [Key]
        [Required]
        public int MissionId { get; set; }

        public string MissionTitle { get; set; }

        public string MissionDescription { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

        public ICollection<CountyMissions> CountyMissions { get; set; }

    }
}
