using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Report
{
    [Table("ReportTypes")]
    public class ReportType
    {
        public Guid ClientId { get; set; }

        [Key]
        public int UId { get; set; }
        public string? Descr { get; set; }
        public double? TipOutPercent { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public int? SNum { get; set; } = -1;
    }

    public class ReportTypeUpdate
    {
        [NotMapped]
        public required int UId { get; set; }
        public string? Descr { get; set; }
        public double? TipOutPercent { get; set; }
        public short? UpdateStatus { get; set; }
        public int? SNum { get; set; }
    }
}
