﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HseqCentral.Models
{
    public abstract class HseqRecord
    {
        public HseqRecord() {

            this.LinkedRecords = new HashSet<HseqRecord>();
        }

        public HseqRecord(HseqRecord record)
        {
            this.AlfrescoNoderef = record.AlfrescoNoderef;
            this.Title = record.Title;
            this.Description = record.Description;
            this.HseqCaseFile = record.HseqCaseFile;
            this.HseqCaseFileID = record.HseqCaseFileID;
            this.HseqRecordID = record.HseqRecordID;
        }


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


        public Nullable<int> MainRecordId { get; set; }
        public virtual ICollection<HseqRecord> LinkedRecords { get; set; }
        public virtual HseqRecord MainRecord { get; set; }

        
        public int? HseqCaseFileID { get; set; }

        public virtual HseqCaseFile HseqCaseFile { get; set; }
    }
}