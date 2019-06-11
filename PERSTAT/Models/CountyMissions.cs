using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models.ViewModels
{
    public class CountyMissions
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int CountyId { get; set; }
        public Counties County { get; set; }
        [Required]
        public int MissionId { get; set; }
        public Missions Mission { get; set; }

    }

}
