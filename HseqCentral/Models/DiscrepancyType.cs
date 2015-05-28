﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HseqCentral.Models
{
    public class DiscrepancyType
    {
        [Key]
        public int DiscrepancyTypeID { get; set; }

        [Display(Name = "Discrepancy Type")]
        public String Name { get; set; }

    }
}