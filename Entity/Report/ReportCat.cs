using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Report
{
    [Table("REPORTCAT")]
    public class ReportCat
    {
        public Guid ClientId { get; set; }

        [Key]
        public int REPORTNO { get; set; }
        public required string DESCRIPT { get; set; }
        public short TAX1 { get; set; } = 0;
        public short TAX2 { get; set; } = 0;
        public short TAX3 { get; set; } = 0;
        public short TAX4 { get; set; } = 0;
        public short TAX5 { get; set; } = 0;
        public required int SUMMARYNUM { get; set; } //* Summary group ID
        public short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? PRINTLOC { get; set; }
        public string? SCHEDULE { get; set; }
        public int? MODIFYSCR1 { get; set; }
        public int? MODIFYSCR2 { get; set; }
        public int? MODIFYSCR3 { get; set; }
        public int? MODIFYSCR4 { get; set; }
        public int? MODIFYSCR5 { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public int? RevCenter { get; set; } = 999;
        public string? PLink { get; set; }
        public int? ConfigNum { get; set; } = 0;
        public int? PrintPriority { get; set; } = 0;
        public double? Tax1Quan { get; set; } = 0;
        public double? Tax2Quan { get; set; } = 0;
        public double? Tax3Quan { get; set; } = 0;
        public double? Tax4Quan { get; set; } = 0;
        public double? Tax5Quan { get; set; } = 0;
        public int? SNUM { get; set; } = -1;
        public long? ReflectionUpdate { get; set; } = 0;
    }

    public class ReportCatUpdate
    {
        [Key]
        public required int REPORTNO { get; set; }
        public string? DESCRIPT { get; set; }
        public short? TAX1 { get; set; }
        public short? TAX2 { get; set; }
        public short? TAX3 { get; set; }
        public short? TAX4 { get; set; }
        public short? TAX5 { get; set; }
        public int? SUMMARYNUM { get; set; }
        public short? ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? PRINTLOC { get; set; }
        public string? SCHEDULE { get; set; }
        public int? MODIFYSCR1 { get; set; }
        public int? MODIFYSCR2 { get; set; }
        public int? MODIFYSCR3 { get; set; }
        public int? MODIFYSCR4 { get; set; }
        public int? MODIFYSCR5 { get; set; }
        public short? UpdateStatus { get; set; }
        public int? RevCenter { get; set; }
        public string? PLink { get; set; }
        public int? ConfigNum { get; set; }
        public int? PrintPriority { get; set; }
        public double? Tax1Quan { get; set; }
        public double? Tax2Quan { get; set; }
        public double? Tax3Quan { get; set; }
        public double? Tax4Quan { get; set; }
        public double? Tax5Quan { get; set; }
        public int? SNUM { get; set; }
        public long? ReflectionUpdate { get; set; }
    }
}
