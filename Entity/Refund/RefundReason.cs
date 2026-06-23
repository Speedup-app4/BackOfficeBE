using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Refund
{
    [Table("REFUNDREASONS")]
    public class RefundReason
    {
        public Guid ClientId { get; set; }

        [Key]
        public int REFNUM { get; set; }
        public required string DESCRIPT { get; set; }
        public short? REDUCEINV { get; set; }
        public short? PRINTRECEIPT { get; set; }
        public int? PRINTCHANNEL { get; set; }
        public short? SECLEVEL { get; set; }
        public short ISACTIVE { get; set; } = 1;
        public string? PLink { get; set; }
        public int UpdateStatus { get; set; } = 1;
        public int SNUM { get; set; } = -1;
    }

    public class RefundReasonUpdate
    {
        [NotMapped]
        public required int REFNUM { get; set; }
        public string? DESCRIPT { get; set; }
        public short? REDUCEINV { get; set; }
        public short? PRINTRECEIPT { get; set; }
        public int? PRINTCHANNEL { get; set; }
        public short? SECLEVEL { get; set; }
        public short? ISACTIVE { get; set; }
        public string? PLink { get; set; }
        public int? UpdateStatus { get; set; }
        public int? SNUM { get; set; }
    }
}
