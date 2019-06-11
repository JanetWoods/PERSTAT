﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class States
    {
        [Key]
        [Required]
        public int StateId { get; set; }

        public string StateShort { get; set; }

        public string StateName { get; set; }

        public ICollection<Counties> Counties { get; set; }

        public ICollection<Locations> Locations { get; set; }
        public ICollection<Organization> Organizations { get; set; }

    }
}