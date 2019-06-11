using PERSTAT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Counties
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CountyName { get; set; }

        public int StateId { get; set; }
        public States State { get; set; }

        public ICollection<CountyMissions> CountyMissions { get; set; }

    }
}
