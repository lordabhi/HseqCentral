﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HseqCentral.Models
{
    public class HseqCentralContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HseqCentralContext() : base("name=HseqCentralContext")
        {
        }

        public System.Data.Entity.DbSet<HseqCentral.Models.HseqCaseFile> HseqCaseFiles { get; set; }

        public System.Data.Entity.DbSet<HseqCentral.Models.Ncr> NcrRecords { get; set; }

        public System.Data.Entity.DbSet<HseqCentral.Models.Fis> FisRecords { get; set; }

        public System.Data.Entity.DbSet<HseqCentral.Models.DiscrepancyType> DiscrepancyTypes { get; set; }
    
    }
}
