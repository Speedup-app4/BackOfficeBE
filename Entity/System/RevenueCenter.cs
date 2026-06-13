using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.System
{
    [Table("REVENUECENTER")]
    public class RevenueCenter
    {
        public Guid ClientId { get; set; }

        [Key]
        public required int REVCENTER { get; set; }
        public required string DESCRIPTION { get; set; }
        public required short ISACTIVE { get; set; }
        public int? UPDATESTATUS { get; set; } = 1;
        public string? PLink { get; set; }
        public int? SNUM { get; set; } = -1;
    }
}
