using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HseqCentral.Models
{
    public class Ncr : HseqRecord
    {

        public NcrSource NcrSource { get; set; }

        public NcrState NcrState { get; set; }

        public int DiscrepancyTypeID { get; set; }

        public virtual DiscrepancyType DiscrepancyType { get; set; }

    }
}