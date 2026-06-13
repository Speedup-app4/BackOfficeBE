using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity
{
    [Table("SUMMARYGROUP")]
    public class SummaryGroup
    {
        public Guid ClientId { get; set; }

        [Key]
        public int SUMMARYNUM { get; set; }
        public required string DESCRIPT { get; set; }
        public required short ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? SumType { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public int? reporttype { get; set; }
        public string? PLink { get; set; }
        public int? SNUM { get; set; } = -1;
        public long? ReflectionUpdate { get; set; } = 0;
    }

    public class SummaryGroupUpdate
    {
        [NotMapped]
        public required int SUMMARYNUM { get; set; }
        public string? DESCRIPT { get; set; }
        public short? ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? SumType { get; set; }
        public short? UpdateStatus { get; set; }
        public int? reporttype { get; set; }
        public string? PLink { get; set; }
        public int? SNUM { get; set; }
        public long? ReflectionUpdate { get; set; }
    }
}
