using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Table
{
    [Table("Sections")]
    public class Section
    {
        public Guid ClientId { get; set; }

        [Key]
        public int SECNUM { get; set; }
        public string? DESCRIPT { get; set; }
        public double? MinCharge { get; set; }
        public double? MinCover { get; set; }
        public short? ISPOOL { get; set; }
        public short? LOCKOUTTABS { get; set; }
        public short ISACTIVE { get; set; } = 1;
        public short? POSTOPX { get; set; }
        public short? POSTOPY { get; set; }
        public short UpdateStatus { get; set; } = 1;
        public int HIDEPOS { get; set; } = 0;
        public string? PLink { get; set; }
        public short AUTOSEAT { get; set; } = 0;
        public int RevCenter { get; set; } = 0;
        public int SNUM { get; set; } = -1;
        public long ReflectionUpdate { get; set; } = 0;
    }

    public class SectionUpdate
    {
        [NotMapped]
        public required int SECNUM { get; set; }
        public string? DESCRIPT { get; set; }
        public double? MinCharge { get; set; }
        public double? MinCover { get; set; }
        public short? ISPOOL { get; set; }
        public short? LOCKOUTTABS { get; set; }
        public short? ISACTIVE { get; set; }
        public short? POSTOPX { get; set; }
        public short? POSTOPY { get; set; }
        public short? UpdateStatus { get; set; }
        public int? HIDEPOS { get; set; }
        public string? PLink { get; set; }
        public short? AUTOSEAT { get; set; }
        public int? RevCenter { get; set; }
        public int? SNUM { get; set; }
        public long? ReflectionUpdate { get; set; }
    }
}
