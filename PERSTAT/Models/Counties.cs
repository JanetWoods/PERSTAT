﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERSTAT.Models
{
    public class Counties
    {
        public int Id { get; set; }
        public string CountyName { get; set; }

        public int StateId { get; set; }
        public States State { get; set; }

   

    }
}
