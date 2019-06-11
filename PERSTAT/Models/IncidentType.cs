using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class IncidentType
    {
        [Key]
        [Required]
        public int IncidentTypeId { get; set; }
        public string TypeIncident { get; set; }

        public ICollection<Incident> Incidents { get; set; }
    }
}
