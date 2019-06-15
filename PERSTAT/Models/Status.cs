using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Status
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string StatusName { get; set; }

        public string StatusDescription { get; set; }

        public ICollection<People> People { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}
