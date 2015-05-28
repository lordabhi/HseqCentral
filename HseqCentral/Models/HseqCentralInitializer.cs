using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HseqCentral.Models
{
    public class HseqCentralInitializer : DropCreateDatabaseIfModelChanges<HseqCentralContext>
    {
        protected override void Seed(HseqCentralContext context) 
        { 
            var discrepancyTypes = new List<DiscrepancyType>{

                new DiscrepancyType{Name = "OS&D"},
                new DiscrepancyType{Name = "Wrong Material"},
                new DiscrepancyType{Name = "Testing Failure"},
                new DiscrepancyType{Name = "Weld Quality"},
                new DiscrepancyType{Name = "Fitting Error"}
            };

            foreach (var temp in discrepancyTypes) {

                context.DiscrepancyTypes.Add(temp);
            }
            context.SaveChanges();
        
        }


    }
}