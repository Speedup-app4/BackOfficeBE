using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Table
{
    [Table("TABLESETUP")]
    public class TableSetup
    {
        public Guid ClientId { get; set; }

        [Key]
        public int TABLENUM { get; set; }
        public int? SECNUM { get; set; }
        public short? NUMCUSTOMER { get; set; }
        public short? UpdateStatus { get; set; }
        public int? MINNUMCUST { get; set; }
        public int? MAXNUMCUST { get; set; }
        public int? CANRESERVE { get; set; }
        public string? PLink { get; set; }
        public int? SaleTypeIndex { get; set; }
        public int? SNUM { get; set; }
    }

    public class TableSetupUpdate
    {
        [NotMapped]
        public required int TABLENUM { get; set; }
        public int? SECNUM { get; set; }
        public short? NUMCUSTOMER { get; set; }
        public short? UpdateStatus { get; set; }
        public int? MINNUMCUST { get; set; }
        public int? MAXNUMCUST { get; set; }
        public int? CANRESERVE { get; set; }
        public string? PLink { get; set; }
        public int? SaleTypeIndex { get; set; }
        public int? SNUM { get; set; }
    }
}
