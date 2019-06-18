using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PERSTAT.Models;
namespace PERSTAT.Models.ViewModels
{
    public class AssignmentsWithPeople
    {
        [Key]
        [Required]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        public IEnumerable<Assignment> Assignments { get; set; }

        public int PersonId { get; set; }
        public People People { get; set; }
    }   
}
