using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HseqCentral.Models
{
    public abstract class HseqRecord
    {
        [Key]
        public int HseqRecordID { get; set; }

        public int? AlfrescoNoderef { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Description { get; set; }

        public RecordType RecordType { get; set; }

        public String EnteredBy { get; set; }

        public String ReportedBy { get; set; }

        public String QualityCoordinator { get; set; }

        /////////////////////////////////////////////////////////////////

       // public virtual IEnumerable<HseqRecord> LinkedRecords { get; set; }

        /////////////////////////////////////////////////////////////////
        public int? HseqCaseFileID { get; set; }

        public virtual HseqCaseFile HseqCaseFile { get; set; }
    }
}